using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Abstract;
using EsitCV.Business.Abstract;
using EsitCV.Business.Utilities;
using AutoMapper;
using EsitCV.Data.Concrete.Context;
using EsitCV.Entities.Dtos.UserProfileDtos;
using Microsoft.AspNetCore.Http;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Concrete;
using Microsoft.EntityFrameworkCore;
using EsitCV.Entities.Concrete;

namespace EsitCV.Business.Concrete
{
    public class UserProfileManager: ManagerBase, IUserProfileService
    {
        IHttpContextAccessor _httpContextAccessor;

        public UserProfileManager(EsitCVContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult> AddAsync(UserProfileAddDto userProfileAddDto)//bunu kullanıcı register olurken oluşturcam ama kalsın
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult> UpdateAsync(UserProfileUpdateDto userProfileUpdateDto) //burası da daha detaylı olcak
        {
            throw new NotImplementedException();
        }

        
        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<UserProfile> query = DbContext.Set<UserProfile>().Include(a => a).ThenInclude(a => a.User).AsNoTracking();
            if (isDeleted.HasValue)
                query = query.Where(a => a.IsActive == isDeleted);
            switch (orderBy)
            {
                case OrderBy.Id:
                    query = isAscending ? query.OrderBy(a => a.ID) : query.OrderByDescending(a => a.ID);
                    break;
                case OrderBy.Az:
                    query = isAscending ? query.OrderBy(a => a.User.FirstName) : query.OrderByDescending(a => a.User.FirstName);
                    break;
                case OrderBy.CreatedDate:
                    query = isAscending ? query.OrderBy(a => a.CreatedDate) : query.OrderByDescending(a => a.CreatedDate);
                    break;
                default:
                    query = isAscending ? query.OrderBy(a => a.CreatedDate) : query.OrderByDescending(a => a.CreatedDate);
                    break;
            }

            if (currentPage != 0 && pageSize != 0)
            {
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<UserProfile>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var userProfile = DbContext.UserProfiles.Include(a => a.About).SingleOrDefaultAsync(a => a.ID == id);
            if (userProfile is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili bulunamadı");
            return new DataResult(ResultStatus.Success, userProfile);
        }

        public async Task<IDataResult> GetByUserIdAsync(int id)
        {
            var user = await DbContext.Users.SingleOrDefaultAsync(a => a.ID == id);
            if (user is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı bulunamadı");
            var userProfileIsExist = DbContext.UserProfiles.Include(a => a.About).SingleOrDefaultAsync(a=>a.UserID==id);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");
            return new DataResult(ResultStatus.Success, userProfileIsExist);
        }

        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var userProfile = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == id);
            if (userProfile is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kullanıcı profili bulunmuyor");
            userProfile.ModifiedDate = DateTime.Now;
            userProfile.IsActive = false;
            userProfile.IsDeleted = true;
            DbContext.UserProfiles.Update(userProfile);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "kullanıcı profilibaşarı ile arşivlendi", userProfile);
        }

        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var userProfile = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == id);
            if (userProfile is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kullanıcı profili bulunmuyor");
            DbContext.UserProfiles.Remove(userProfile);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "kullanıcı profilibaşarı ile silindi", userProfile);
        }

    
    }
}
