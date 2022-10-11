using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.JobApplicationAndJobPostingDtos;
using EsitCV.Shared.Utilities.Results.Abstract;

namespace EsitCV.Business.Abstract
{
    public interface IJobApplicationAndJobPostingService
    {
        Task<IDataResult> AddAsync(JobApplicationAndJobPostingAddDto jobApplicationAndJobPostingAddDto);
        Task<IDataResult> UpdateAsync(JobApplicationAndJobPostingUpdateDto jobApplicationAndJobPostingUpdateDto);
        Task<IDataResult> DeleteByJobApplicationIdAndJobPostingIdAsync(int jobApplicationId, int jobPostingId);
        Task<IDataResult> GetByJobApplicationIdAsync(int jobApplicationId, bool includeJobPosting);
        Task<IDataResult> GetByJobPostingIdAsync(int jobPostingId, bool includeJobApplication);
    }
}
