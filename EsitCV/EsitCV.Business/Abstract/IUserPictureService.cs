using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.UserPictureDtos;
using EsitCV.Shared.Utilities.Results.Abstract;

namespace EsitCV.Business.Abstract
{
    public interface IUserPictureService
    {
        Task<IDataResult> AddAsync(UserPictureAddDto userPictureAddDto);
        Task<IDataResult> UpdateAsync(UserPictureUpdateDto userPictureAddDto);
        Task<IDataResult> GetByIdAsync(int id);
        Task<IDataResult> GetByUserIdAsync(int id);
        Task<IDataResult> DeleteByFileUrlAsync(string fileUrl);
    }
}
