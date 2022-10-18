using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.UserDisabilityDtos;
using EsitCV.Shared.Utilities.Results.Abstract;

namespace EsitCV.Business.Abstract
{
    public interface IUserAndDisabilityService
    {
        Task<IDataResult> AddAsync(UserAndDisabilityAddDto userAndDisabilityAddDto);
        //Task<IDataResult> UpdateAsync(); //update eklicem ama engel yüzdesi update edilecek sadece
        Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy);
        Task<IDataResult> GetAllByDisabilityIdAsync(int disabilityID,bool inculudeUser);
        Task<IDataResult> GetAllByUserIdAsync(int userID, bool inculudeDisability);
        Task<IDataResult> DeleteByUserIdAndDisabilityIdAsync(int userID, int disabilityID);
    }
}
