using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Abstract;

namespace EsitCV.Business.Abstract
{
    public interface ICompanyPictureService
    {
        Task<IDataResult> AddAsync();
        Task<IDataResult> UpdateAsync();
        Task<IDataResult> GetByIdAsync();
        Task<IDataResult> GetByCompanyIdAsync();
        Task<IDataResult> DeleteByFileNameAsync();
    }
}
