using EsitCV.Entities.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.Abstract
{
    public interface IAreasOfInterestService
    {
        Task<IDataResult> AddAsync();
        Task<IDataResult> UpdateAsync();
        Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy);
        Task<IDataResult> GetByIdAsync(int id);
        Task<IDataResult> GetByProfileIdAsync(int id);
        Task<IDataResult> DeleteByIdAsync(int id);
        Task<IDataResult> HardDeleteByIdAsync(int id);
    }
}
