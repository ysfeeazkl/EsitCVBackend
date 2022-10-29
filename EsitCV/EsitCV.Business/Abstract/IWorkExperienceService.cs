using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.FeaturesDtos.OrganizationDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.WorkExperienceDtos;
using EsitCV.Shared.Utilities.Results.Abstract;

namespace EsitCV.Business.Abstract
{
    public interface IWorkExperienceService
    {
        Task<IDataResult> AddAsync(WorkExperienceAddDto workExperienceAddDto);
        Task<IDataResult> UpdateAsync(WorkExperienceUpdateDto workExperienceUpdateDto);
        Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy);
        Task<IDataResult> GetByIdAsync(int id);
        Task<IDataResult> GetAllByProfileIdAsync(int id);
        Task<IDataResult> DeleteByIdAsync(int id);
        Task<IDataResult> HardDeleteByIdAsync(int id);
    }
}
