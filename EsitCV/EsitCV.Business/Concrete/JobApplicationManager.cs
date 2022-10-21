using EsitCV.Entities.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Business.Abstract;
using EsitCV.Business.Utilities;
using AutoMapper;
using EsitCV.Data.Concrete.Context;
using EsitCV.Entities.Dtos.JobApplicationDtos;
using EsitCV.Business.ValidationRules.FluentValidation.JobApplicationValidators;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using EsitCV.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using EsitCV.Entities.Dtos.AnswerDtos;
using EsitCV.Entities.Dtos.JobPostingDtos;

namespace EsitCV.Business.Concrete
{
    public class JobApplicationManager : ManagerBase, IJobApplicationService
    {
        IHttpContextAccessor _httpContextAccessor;
        public JobApplicationManager(EsitCVContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult> AddAsync(JobApplicationAddDto jobApplicationAddDto)
        {
            ValidationTool.Validate(new JobApplicationAddDtoValidator(), jobApplicationAddDto);

            var userIsExist = await DbContext.Users.SingleOrDefaultAsync(a => a.ID == jobApplicationAddDto.UserID);
            if (userIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kullanıcı bulunamadı");
            var jobPosting = await DbContext.JobPostings.SingleOrDefaultAsync(a => a.ID == jobApplicationAddDto.JobPostingID);
            if (jobPosting is null)
                return new DataResult(ResultStatus.Error, "Böyle bir iş ilanı bulunamadı");
            var cvIsExist = await DbContext.CurriculumVitaes.SingleOrDefaultAsync(a => a.UserID == userIsExist.ID);
            if (cvIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir cv bulunamadı");

            var answers = Mapper.Map<List<Answer>>(jobApplicationAddDto.Answers);

            var jobApplication = Mapper.Map<JobApplication>(jobApplicationAddDto);
            jobApplication.CreatedDate = DateTime.Now;
            //jobApplication.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            jobApplication.User = userIsExist;
            jobApplication.UserID = userIsExist.ID;
            //jobApplication.CurriculumVitaeID = cvIsExist.ID;
            //jobApplication.CurriculumVitae= cvIsExist;
            jobApplication.JobPostingID = jobPosting.ID;
            jobApplication.JobPosting= jobPosting;

            //jobPosting.JobApplications.Add(jobApplication);
            DbContext.JobPostings.Update(jobPosting);
            await DbContext.JobApplications.AddAsync(jobApplication);
            await DbContext.SaveChangesAsync();


            if (jobApplicationAddDto.Answers.Count() > 0)
            {

                jobApplication.Answers = new List<Answer>();

                foreach (var answer in answers)
                {
                    answer.JobApplication = jobApplication;
                    answer.JobApplicationID = jobApplication.ID;
                    //jobPosting.Questions.Add(question);                                

                    await DbContext.Answers.AddAsync(answer);
                    //await Task.Delay(10);
                }
                DbContext.JobApplications.Update(jobApplication);
                await DbContext.SaveChangesAsync(); //job application ve answer arasında ki bağlantıdan dolayı burası patlıyor
                return new DataResult(ResultStatus.Success, "İş başvurusu ve cevapları başarıyla Eklendi.", jobPosting);

            }

            return new DataResult(ResultStatus.Success, "İş başvurusu başarıyla Eklendi.", jobApplication);
        }


        public async Task<IDataResult> UpdateAsync(JobApplicationUpdateDto jobApplicationUpdateDto)
        {
            ValidationTool.Validate(new JobApplicationUpdateDtoValidator(), jobApplicationUpdateDto);

            var cvIsExist = await DbContext.CurriculumVitaes.SingleOrDefaultAsync(a => a.ID == jobApplicationUpdateDto.CurriculumVitaeID);
            if (cvIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir cv bulunamadı");

            var jobApplication = Mapper.Map<JobApplication>(jobApplicationUpdateDto);
            jobApplication.CreatedDate = DateTime.Now;
            //jobApplication.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            //jobApplication.CurriculumVitaeID = cvIsExist.ID;
            //jobApplication.CurriculumVitae = cvIsExist;

            DbContext.JobApplications.Update(jobApplication);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "İş başvurusu başarıyla güncellendi.", jobApplication);
        }

        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<JobApplication> query = DbContext.Set<JobApplication>().Include(a => a.User).AsNoTracking();
            if (isDeleted.HasValue)
                query = query.Where(a => a.IsActive == isDeleted);
            switch (orderBy)
            {
                case OrderBy.Id:
                    query = isAscending ? query.OrderBy(a => a.ID) : query.OrderByDescending(a => a.ID);
                    break;
                case OrderBy.Az:
                    query = isAscending ? query.OrderBy(a => a.User.FirstName) : query.OrderByDescending(a => a.User.FirstName);
                    break;
                case OrderBy.CreatedDate:
                    query = isAscending ? query.OrderBy(a => a.CreatedDate) : query.OrderByDescending(a => a.CreatedDate);
                    break;
                default:
                    query = isAscending ? query.OrderBy(a => a.CreatedDate) : query.OrderByDescending(a => a.CreatedDate);
                    break;
            }

            if (currentPage != 0 && pageSize != 0)
            {
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<JobApplication>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetAllByUserIdAsync(int id)
        {
            var companyIsExist = await DbContext.Users.SingleOrDefaultAsync(a => a.ID == id);
            if (companyIsExist is not null)
                return new DataResult(ResultStatus.Wrong, "böyle bir kullanıcı bulunamadı");
            var query = DbContext.Set<JobPosting>().Where(a => a.CompanyID == id).AsNoTracking();
            if (query.Count() < 1)
                return new DataResult(ResultStatus.Wrong, "herhangi bir iş ilanı bulunamadı");

            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {

            var jobApplication = await DbContext.JobApplications.SingleOrDefaultAsync(a => a.ID == id);
            if (jobApplication is not null)
                return new DataResult(ResultStatus.Wrong, "böyle bir iş başvurus bulunamadı");
            return new DataResult(ResultStatus.Success, jobApplication);
        }

        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var jobApplication = await DbContext.JobApplications.SingleOrDefaultAsync(a => a.ID == id);
            if (jobApplication is not null)
                return new DataResult(ResultStatus.Wrong, "böyle bir iş başcurusu bulunamadı");

            DbContext.JobApplications.Remove(jobApplication);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "İş başvurusu başarıyla silindi", jobApplication);
        }
        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var jobApplication = await DbContext.JobApplications.SingleOrDefaultAsync(a => a.ID == id);
            if (jobApplication is not null)
                return new DataResult(ResultStatus.Wrong, "böyle bir iş başcurusu bulunamadı");

            jobApplication.ModifiedDate = DateTime.Now;
            jobApplication.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);
            jobApplication.IsActive = false;
            jobApplication.IsDeleted = true;

            DbContext.JobApplications.Update(jobApplication);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "İş başvurusu başarıyla arşivlendi", jobApplication);
        }

    }
}
