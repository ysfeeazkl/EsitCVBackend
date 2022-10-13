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
            throw new NotImplementedException();
        }

        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult> GetByQuestionIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult> GetByUserIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
