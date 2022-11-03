using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EsitCV.Business.Abstract;
using EsitCV.Business.AbstractUtilities;
using EsitCV.Business.Utilities;
using EsitCV.Business.ValidationRules.FluentValidation.DisabilityValidators;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.AboutValidators;
using EsitCV.Data.Concrete.Context;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Concrete.Disableds;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.DisabilityDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.AboutDtos;
using EsitCV.Shared.Utilities.Results.Abstract;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EsitCV.Business.Concrete
{
    public class AboutManager: ManagerBase,IAboutService
    {
        IHttpContextAccessor _httpContextAccessor;
        public AboutManager(EsitCVContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult> AddAsync(AboutAddDto aboutAddDto)
        {
            ValidationTool.Validate(new AboutAddDtoValidator(), aboutAddDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == aboutAddDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");
            var abuotIsExist = await DbContext.Abouts.SingleOrDefaultAsync(a => a.UserProfileID == aboutAddDto.UserProfileID);
            if (abuotIsExist is not null)
                return new DataResult(ResultStatus.Error, "Bu profilin hakkında kısmı zaten var");

            var about = Mapper.Map<About>(aboutAddDto);
            about.CreatedDate = DateTime.Now;
            about.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserID").Value);

            userProfileIsExist.AboutID = about.ID;
            userProfileIsExist.About = about;

            await DbContext.Abouts.AddAsync(about);
            await DbContext.SaveChangesAsync();

            DbContext.UserProfiles.Update(userProfileIsExist);
            await DbContext.SaveChangesAsync();


            return new DataResult(ResultStatus.Success, "Hakkında kısımı başarıyla Eklendi.", about);
        }
        public async Task<IDataResult> UpdateAsync(AboutUpdateDto aboutUpdateDto)
        {
            ValidationTool.Validate(new AboutUpdateDtoValidator(), aboutUpdateDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == aboutUpdateDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");
            var abuotIsExist = await DbContext.Abouts.SingleOrDefaultAsync(a => a.UserProfileID == aboutUpdateDto.UserProfileID);
            if (abuotIsExist is null)
                return new DataResult(ResultStatus.Error, "Bu profilin hakkında kısmı yok");

            var about = Mapper.Map<About>(aboutUpdateDto);
            about.ModifiedDate = DateTime.Now;
            //about.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            DbContext.Abouts.Update(about);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Hakkında kısımı başarıyla Güncellendi.", about);
        }



        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            var result = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)!.Value;

            IQueryable<About> query = DbContext.Set<About>().Include(a=>a.UserProfile).ThenInclude(a=>a.User).AsNoTracking();
            if (isDeleted.HasValue)
                query = query.Where(a => a.IsActive == isDeleted);
            switch (orderBy)
            {
                case OrderBy.Id:
                    query = isAscending ? query.OrderBy(a => a.ID) : query.OrderByDescending(a => a.ID);
                    break;
                case OrderBy.Az:
                    query = isAscending ? query.OrderBy(a => a.UserProfile.User.FirstName) : query.OrderByDescending(a => a.UserProfile.User.FirstName);
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
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<About>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
           
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var abuotIsExist = await DbContext.Abouts.SingleOrDefaultAsync(a => a.ID == id);
            if (abuotIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir hakında bulunamadı");
            return new DataResult(ResultStatus.Success, abuotIsExist);

        }

        public async Task<IDataResult> GetByProfileIdAsync(int id)
        {
            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == id);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");
            var abuotIsExist = await DbContext.Abouts.SingleOrDefaultAsync(a => a.UserProfileID == id);
            if (abuotIsExist is null)
                return new DataResult(ResultStatus.Error, "Bu profilin hakkında kısmı yok");
            return new DataResult(ResultStatus.Success, abuotIsExist);

        }

        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var about = await DbContext.Abouts.SingleOrDefaultAsync(a => a.ID == id);
            if (about is null)
                return new DataResult(ResultStatus.Error, "Böyle bir hakkında bulunmuyor");
            about.ModifiedDate = DateTime.Now;
            about.IsActive = false;
            about.IsDeleted = true;
            DbContext.Abouts.Update(about);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Hakkında kısmı başarı ile arşivlendi", about);
        }
        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var about = await DbContext.Abouts.SingleOrDefaultAsync(a => a.ID == id);
            if (about is null)
                return new DataResult(ResultStatus.Error, "Böyle bir hakkında bulunmuyor");
            DbContext.Abouts.Remove(about);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Hakkında kısmı başarı ile silindi",about);
        }

       
    }
}
