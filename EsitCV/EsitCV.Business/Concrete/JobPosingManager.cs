using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Abstract;
using EsitCV.Business.Abstract;
using AutoMapper;
using EsitCV.Data.Concrete.Context;
using EsitCV.Business.Utilities;
using EsitCV.Entities.Dtos.JobPostingDtos;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using EsitCV.Business.ValidationRules.FluentValidation.JobPostingValidators;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.QuestionDtos;

namespace EsitCV.Business.Concrete
{
    public class JobPosingManager : ManagerBase, IJobPosingService
    {
        IHttpContextAccessor _httpContextAccessor;
        public JobPosingManager(EsitCVContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult> AddAsync(JobPostingAddDto jobPostingAddDto) //burayı tekrar kontrol et
        {
            ValidationTool.Validate(new JobPostingAddDtoValidator(), jobPostingAddDto);

            var companyIsExist = await DbContext.Companies.SingleOrDefaultAsync(a => a.ID == jobPostingAddDto.CompanyID);
            if (companyIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir şirket bulunamadı");

            var questions = Mapper.Map<List<Question>>(jobPostingAddDto.Questions);

            var jobPosting = Mapper.Map<JobPosting>(jobPostingAddDto);
            jobPosting.CreatedDate = DateTime.Now;
            //jobPosting.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            jobPosting.CompanyID = companyIsExist.ID;
            jobPosting.Company = companyIsExist;

            await DbContext.JobPostings.AddAsync(jobPosting);
            await DbContext.SaveChangesAsync();

            if (jobPostingAddDto.Questions.Count() > 0)
            {                                                                            
                                                                                         
                jobPosting.Questions = new List<Question>();                             
                                                                                         
                foreach (var question in questions)                                      
                {                                                                        
                    question.JobPosting = jobPosting;                                    
                    question.JobPostingID = jobPosting.ID;                               
                    //jobPosting.Questions.Add(question);                                
                                                                                         
                    await DbContext.Questions.AddAsync(question);                        
                    //await Task.Delay(10);
                }
                DbContext.JobPostings.Update(jobPosting);
                await DbContext.SaveChangesAsync();
                //return new DataResult(ResultStatus.Success, "İş ilanı ve soruları başarıyla Eklendi.", new List<object> { jobPosting, questions });
                return new DataResult(ResultStatus.Success, "İş ilanı ve soruları başarıyla Eklendi.",jobPosting);

            }

            return new DataResult(ResultStatus.Success, "İş ilanı başarıyla Eklendi.", jobPosting);
        }
        public async Task<IDataResult> UpdateAsync(JobPostingUpdateDto jobPostingUpdateDto)
        {
            ValidationTool.Validate(new JobPostingUpdateDtoValidator(), jobPostingUpdateDto);

            var jobPostingIsExist = await DbContext.Companies.SingleOrDefaultAsync(a => a.ID == jobPostingUpdateDto.ID);
            if (jobPostingIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir iş ilanı bulunamadı");

            var jobPosting = Mapper.Map<JobPosting>(jobPostingUpdateDto);
            jobPosting.ModifiedDate = DateTime.Now;
            //jobPosting.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            DbContext.JobPostings.Update(jobPosting);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "İş ilanı başarıyla güncellendi.", jobPosting);
        }

        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<JobPosting> query = DbContext.Set<JobPosting>().Include(a=>a.Questions).Include(a => a.Company).AsNoTracking();
            if (isDeleted.HasValue)
                query = query.Where(a => a.IsActive == isDeleted);
            switch (orderBy)
            {
                case OrderBy.Id:
                    query = isAscending ? query.OrderBy(a => a.ID) : query.OrderByDescending(a => a.ID);
                    break;
                case OrderBy.Az:
                    query = isAscending ? query.OrderBy(a => a.Company.Name) : query.OrderByDescending(a => a.Company.Name);
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
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<JobPosting>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetAllByCompanyIdAsync(int id)
        {
            var companyIsExist = await DbContext.Companies.SingleOrDefaultAsync(a => a.ID == id);
            if (companyIsExist is null)
                return new DataResult(ResultStatus.Wrong, "böyle bir şirket bulunamadı");

            var query = DbContext.Set<JobPosting>().Include(a=>a.Questions).Include(a => a.JobApplications).Where(a => a.CompanyID == id).AsNoTracking();
            if (query.Count() < 1)
                return new DataResult(ResultStatus.Wrong, "herhangi bir iş ilanı bulunamadı");

            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var jobPosting =  DbContext.JobPostings.Where(a => a.ID == id).Include(a => a.Questions).Include(a => a.JobApplications);
            if (jobPosting is null)
                return new DataResult(ResultStatus.Wrong, "böyle bir iş ilanı bulunamadı");
            return new DataResult(ResultStatus.Success, jobPosting);

        }


        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var jobPosting = await DbContext.JobPostings.SingleOrDefaultAsync(a => a.ID == id);
            if (jobPosting is not null)
                return new DataResult(ResultStatus.Wrong, "böyle bir iş ilanı bulunamadı");

            jobPosting.ModifiedDate = DateTime.Now;
            //jobPosting.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);
            jobPosting.IsActive = false;
            jobPosting.IsDeleted = true;

            DbContext.JobPostings.Update(jobPosting);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "İş ilanı başarıyla arşivlendi", jobPosting);
        }
        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var jobPosting = await DbContext.JobPostings.SingleOrDefaultAsync(a => a.ID == id);
            if (jobPosting is not null)
                return new DataResult(ResultStatus.Wrong, "böyle bir iş ilanı bulunamadı");

            DbContext.JobPostings.Remove(jobPosting);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "İş ilanı başarıyla silindi", jobPosting);
        }


    }
}
