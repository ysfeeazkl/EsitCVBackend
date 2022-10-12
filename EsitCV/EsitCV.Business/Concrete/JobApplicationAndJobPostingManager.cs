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
using EsitCV.Entities.Dtos.JobApplicationAndJobPostingDtos;

namespace EsitCV.Business.Concrete
{
    public class JobApplicationAndJobPostingManager: ManagerBase, IJobApplicationAndJobPostingService
    {
        public JobApplicationAndJobPostingManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {

        }

        public Task<IDataResult> AddAsync(JobApplicationAndJobPostingAddDto jobApplicationAndJobPostingAddDto)
        {
            throw new NotImplementedException();
        }
        public Task<IDataResult> UpdateAsync(JobApplicationAndJobPostingUpdateDto jobApplicationAndJobPostingUpdateDto)
        {
            throw new NotImplementedException();
        }

     

        public Task<IDataResult> GetByJobApplicationIdAsync(int jobApplicationId, bool includeJobPosting)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetByJobPostingIdAsync(int jobPostingId, bool includeJobApplication)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> DeleteByJobApplicationIdAndJobPostingIdAsync(int jobApplicationId, int jobPostingId)
        {
            throw new NotImplementedException();
        }
    }
}
