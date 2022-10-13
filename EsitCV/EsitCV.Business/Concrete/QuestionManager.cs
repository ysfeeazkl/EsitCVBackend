using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Abstract;
using EsitCV.Business.Abstract;
using EsitCV.Business.Utilities;
using AutoMapper;
using EsitCV.Data.Concrete.Context;
using EsitCV.Entities.Dtos.QuestionDtos;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using EsitCV.Business.ValidationRules.FluentValidation.QuestionValidators;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using EsitCV.Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace EsitCV.Business.Concrete
{
    public class QuestionManager : ManagerBase, IQuestionService
    {

        IHttpContextAccessor _httpContextAccessor;

        public QuestionManager(EsitCVContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult> AddAsync(QuestionAddDto questionAddDto)
        {
            ValidationTool.Validate(new QuestionAddDtoValidator(), questionAddDto);

            var jobPostingIsExist = await DbContext.JobPostings.SingleOrDefaultAsync(a => a.ID == questionAddDto.JobPostingID);
            if (jobPostingIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir iş ilanı bulunamadı");

            var question = Mapper.Map<Question>(questionAddDto);
            question.CreatedDate = DateTime.Now;
            question.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            question.JobPostingID = jobPostingIsExist.ID;
            question.JobPosting = jobPostingIsExist;


            await DbContext.Questions.AddAsync(question);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "İlan sorusu başarıyla Eklendi.", question);
        }
        public async Task<IDataResult> UpdateAsync(QuestionUpdateDto questionUpdateDto)
        {
            ValidationTool.Validate(new QuestionUpdateDtoValidator(), questionUpdateDto);

            var jobPostingIsExist = await DbContext.Questions.SingleOrDefaultAsync(a => a.ID == questionUpdateDto.ID);
            if (jobPostingIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir soru bulunamadı");

            var question = Mapper.Map<Question>(questionUpdateDto);
            question.ModifiedDate = DateTime.Now;
            question.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            DbContext.Questions.Update(question);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "İş ilanı sorusu başarıyla güncellendi.", question);
        }



        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<Question> query = DbContext.Set<Question>().Include(a => a.JobPosting).ThenInclude(a => a.Company).AsNoTracking();
            if (isDeleted.HasValue)
                query = query.Where(a => a.IsActive == isDeleted);
            switch (orderBy)
            {
                case OrderBy.Id:
                    query = isAscending ? query.OrderBy(a => a.ID) : query.OrderByDescending(a => a.ID);
                    break;
                case OrderBy.Az:
                    query = isAscending ? query.OrderBy(a => a.JobPosting.Company.Name) : query.OrderByDescending(a => a.JobPosting.Company.Name);
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
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<Question>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetAllByJobPostingIdAsync(int id)
        {
            var jobPostingsIsExist = await DbContext.JobPostings.SingleOrDefaultAsync(a => a.ID == id);
            if (jobPostingsIsExist is not null)
                return new DataResult(ResultStatus.Wrong, "böyle bir iş ilanı bulunamadı");

            var query = DbContext.Questions.Where(a => a.JobPostingID == id);
            if (query.Count() < 1)
                return new DataResult(ResultStatus.Wrong, "herhangi bir iş ilanı sorusu bulunamadı");

            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var questions = DbContext.Questions.SingleOrDefaultAsync(a => a.ID == id);
            if (questions is null)
                return new DataResult(ResultStatus.Wrong, "herhangi bir soru bulunamadı");
            return new DataResult(ResultStatus.Success, questions);
        }

        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var questions = await DbContext.Questions.SingleOrDefaultAsync(a => a.ID == id);
            if (questions is not null)
                return new DataResult(ResultStatus.Wrong, "böyle bir iş ilanı bulunamadı");

            questions.ModifiedDate = DateTime.Now;
            questions.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);
            questions.IsActive = false;
            questions.IsDeleted = true;

            DbContext.Questions.Update(questions);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "soru başarıyla arşivlendi", questions);
        }
        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var questions = await DbContext.Questions.SingleOrDefaultAsync(a => a.ID == id);
            if (questions is not null)
                return new DataResult(ResultStatus.Wrong, "böyle bir iş ilanı bulunamadı");

            DbContext.Questions.Remove(questions);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "soru başarıyla silindi", questions);
        }


    }
}
