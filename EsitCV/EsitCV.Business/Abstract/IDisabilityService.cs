using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.DisabilityDtos;
using EsitCV.Shared.Utilities.Results.Abstract;

namespace EsitCV.Business.Abstract
{
    public interface IDisabilityService
    {
        Task<IDataResult> AddAsync(DisabilityAddDto disabilityAddDto);
        //Task<IDataResult> UpdateAsync();
        Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy);
        Task<IDataResult> GetByIdAsync(int id);
        Task<IDataResult> GetByNameAsync(string disabilityName);
        Task<IDataResult> DeleteByIdAsync(int id); 
        Task<IDataResult> DeleteByNameAsync(string disabilityName);
        Task<IDataResult> HardDeleteByIdAsync(int id);
        Task<IDataResult> HardDeleteByNameAsync(string disabilityName);
    }
}
