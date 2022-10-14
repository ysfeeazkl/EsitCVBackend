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
using EsitCV.Entities.Dtos.AnswerDtos;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using EsitCV.Entities.Concrete;
using EsitCV.Business.ValidationRules.FluentValidation.AnswerValidators;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace EsitCV.Business.Concrete
{
    public class AnswerManager:ManagerBase,IAnswerService
    {
        IHttpContextAccessor _httpContextAccessor;
        public AnswerManager(EsitCVContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult> AddAsync(AnswerAddDto answerAddDto)
        {
            ValidationTool.Validate(new AnswerAddDtoValidator(), answerAddDto);

            var questionsIsExist = await DbContext.Questions.SingleOrDefaultAsync(a => a.ID == answerAddDto.QuestionID);
            if (questionsIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir soru bulunamadı");

            var answer = Mapper.Map<Answer>(answerAddDto);
            answer.CreatedDate = DateTime.Now;
            answer.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            answer.Question = questionsIsExist;
            answer.QuestionID = questionsIsExist.ID;


            await DbContext.Answers.AddAsync(answer);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "İlan sorusu başarıyla Eklendi.", answer);
        }
        public async Task<IDataResult> UpdateAsync(AnswerUpdateDto answerUpdateDto)
        {
            ValidationTool.Validate(new AnswerUpdateDtoValidator(), answerUpdateDto);

            var questionsIsExist = await DbContext.Questions.SingleOrDefaultAsync(a => a.ID == answerUpdateDto.QuestionID);
            if (questionsIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir soru bulunamadı");

            var answer = Mapper.Map<Answer>(answerUpdateDto);
            answer.ModifiedDate = DateTime.Now;
            answer.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);           


            DbContext.Answers.Update(answer);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "İlan sorusu başarıyla Eklendi.", answer);
        }


        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<Answer> query = DbContext.Set<Answer>().Include(a => a.JobApplication).ThenInclude(a=>a.User).AsNoTracking();
            if (isDeleted.HasValue)
                query = query.Where(a => a.IsActive == isDeleted);
            switch (orderBy)
            {
                case OrderBy.Id:
                    query = isAscending ? query.OrderBy(a => a.ID) : query.OrderByDescending(a => a.ID);
                    break;
                case OrderBy.Az:
                    query = isAscending ? query.OrderBy(a => a.JobApplication.User.FirstName) : query.OrderByDescending(a => a.JobApplication.User.FirstName);
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
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<Answer>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var answer = DbContext.Answers.SingleOrDefaultAsync(a => a.ID == id);
            if (answer is null)
                return new DataResult(ResultStatus.Wrong, "herhangi bir cevap bulunamadı");
            return new DataResult(ResultStatus.Success, answer);
        }

        public async Task<IDataResult> GetByQuestionIdAsync(int id)
        {
            var question = DbContext.Questions.SingleOrDefaultAsync(a => a.ID == id);
            if (question is null)
                return new DataResult(ResultStatus.Wrong, "herhangi bir soru bulunamadı");
            var answer = DbContext.Answers.SingleOrDefaultAsync(a => a.QuestionID == question.Id);
            if (answer is null)
                return new DataResult(ResultStatus.Wrong, "herhangi bir cevap bulunamadı");
            return new DataResult(ResultStatus.Success, answer);
        }

        public async Task<IDataResult> GetByUserIdAsync(int id)
        {
            var user = DbContext.Users.SingleOrDefaultAsync(a => a.ID == id);
            if (user is null)
                return new DataResult(ResultStatus.Wrong, "herhangi bir soru bulunamadı");
            var answer = DbContext.Answers.Where(a => a.QuestionID == user.Id);
            if (answer.Count() < 0)
                return new DataResult(ResultStatus.Wrong, "herhangi bir cevap bulunamadı");
            return new DataResult(ResultStatus.Wrong, "herhangi bir cevap bulunamadı");

        }

        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var answer = await DbContext.Answers.SingleOrDefaultAsync(a => a.ID == id);
            if (answer is not null)
                return new DataResult(ResultStatus.Wrong, "böyle bir cevap bulunamadı");

            answer.ModifiedDate = DateTime.Now;
            answer.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);
            answer.IsActive = false;
            answer.IsDeleted = true;

            DbContext.Answers.Update(answer);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "cevap başarıyla arşivlendi", answer);
        }
        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var answer = await DbContext.Answers.SingleOrDefaultAsync(a => a.ID == id);
            if (answer is not null)
                return new DataResult(ResultStatus.Wrong, "böyle bir cevap bulunamadı");

         
            DbContext.Answers.Remove(answer);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "cevap başarıyla silindi", answer);
        }

       
    }
}
