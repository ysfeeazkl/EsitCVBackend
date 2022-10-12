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

namespace EsitCV.Business.Concrete
{
    public class JobPosingManager : ManagerBase, IJobPosingService
    {
        public JobPosingManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {

        }

        public Task<IDataResult> AddAsync(JobPostingAddDto jobPostingAddDto)
        {
            throw new NotImplementedException();
        }
        public Task<IDataResult> UpdateAsync(JobPostingUpdateDto jobPostingUpdateDto)
        {
            throw new NotImplementedException();
        }

      

        public Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetAllByCompanyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<IDataResult> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
