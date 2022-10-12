using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.JobPostingDtos;
using EsitCV.Shared.Utilities.Results.Abstract;


namespace EsitCV.Business.Abstract
{
    public interface IJobPosingService
    {
        Task<IDataResult> AddAsync(JobPostingAddDto jobPostingAddDto);
        Task<IDataResult> UpdateAsync(JobPostingUpdateDto jobPostingUpdateDto);
        Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy);
        Task<IDataResult> GetByIdAsync(int id);
        Task<IDataResult> GetAllByCompanyIdAsync(int id);
        Task<IDataResult> DeleteByIdAsync(int id);
        Task<IDataResult> HardDeleteByIdAsync(int id);
    }
}
