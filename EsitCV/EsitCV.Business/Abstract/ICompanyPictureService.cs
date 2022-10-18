using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.CompanyPicuteDtos;
using EsitCV.Shared.Utilities.Results.Abstract;

namespace EsitCV.Business.Abstract
{
    public interface ICompanyPictureService
    {
        Task<IDataResult> AddAsync(CompanyPictureAddDto companyPictureAddDto);
        Task<IDataResult> UpdateAsync(CompanyPictureUpdateDto companyPictureAddDto);
        Task<IDataResult> GetByIdAsync(int id);
        Task<IDataResult> GetByCompanyIdAsync(int id);
        Task<IDataResult> DeleteByFileUrlAsync(string fileUrl);
    }
}
