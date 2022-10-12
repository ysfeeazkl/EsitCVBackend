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

namespace EsitCV.Business.Concrete
{
    public class AnswerManager:ManagerBase,IAnswerService
    {
        public AnswerManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {

        }

        public Task<IDataResult> AddAsync(AnswerAddDto answerAddDto)
        {
            throw new NotImplementedException();
        }
        public Task<IDataResult> UpdateAsync(AnswerUpdateDto answerUpdateDto)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetByQuestionIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetByUserIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
