using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Abstract;
using EsitCV.Business.Abstract;
using EsitCV.Business.Utilities;
using EsitCV.Data.Concrete.Context;
using AutoMapper;

namespace EsitCV.Business.Concrete
{
    public class LanguageManager : ManagerBase, ILanguageService
    {
        public LanguageManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {

        }

        public Task<IDataResult> AddAsync()
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

        public Task<IDataResult> GetByProfileIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
