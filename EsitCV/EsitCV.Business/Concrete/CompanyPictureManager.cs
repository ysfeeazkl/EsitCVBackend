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

namespace EsitCV.Business.Concrete
{
    public class CompanyPictureManager: ManagerBase, ICompanyPictureService
    {
        public CompanyPictureManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {

        }

        public Task<IDataResult> AddAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> DeleteByFileNameAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetByCompanyIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
