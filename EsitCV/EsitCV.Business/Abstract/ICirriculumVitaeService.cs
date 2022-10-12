using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.CurriculumVitaeDtos;
using EsitCV.Shared.Utilities.Results.Abstract;

namespace EsitCV.Business.Abstract
{
    public interface ICurriculumVitaeService
    {
        Task<IDataResult> AddAsync(CurriculumVitaeAddDto curriculumVitaeAddDto);
        Task<IDataResult> UpdateAsync(CurriculumVitaeUpdateDto curriculumVitaeUpdateDto);
        Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy);
        Task<IDataResult> GetByIdAsync(int id);
        Task<IDataResult> GetByUserIdAsync(int id);
        Task<IDataResult> DeleteByIdAsync(int id);
        Task<IDataResult> HardDeleteByIdAsync(int id);
    }
}
