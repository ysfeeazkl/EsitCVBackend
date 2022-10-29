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
using EsitCV.Entities.Dtos.FeaturesDtos.HobbieDtos;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.CourseValidators;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using Microsoft.EntityFrameworkCore;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.HobbieValidators;

namespace EsitCV.Business.Concrete
{
    public class HobbieManager: ManagerBase, IHobbieService
    {
        public HobbieManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {

        }

        public async Task<IDataResult> AddAsync(HobbieAddDto hobbieAddDto)
        {
            ValidationTool.Validate(new HobbieAddDtoValidator(), hobbieAddDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == hobbieAddDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var hobbie = Mapper.Map<Hobbie>(hobbieAddDto);
            hobbie.CreatedDate = DateTime.Now;
            hobbie.UserProfile = userProfileIsExist;
            //hobbie.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            await DbContext.Hobbies.AddAsync(hobbie);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Kurs başarıyla Eklendi.", hobbie);
        }
        public async Task<IDataResult> UpdateAsync(HobbieUpdateDto hobbieUpdateDto)
        {
            ValidationTool.Validate(new HobbieUpdateDtoValidator(), hobbieUpdateDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == hobbieUpdateDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var hobbie = Mapper.Map<Hobbie>(hobbieUpdateDto);
            hobbie.CreatedDate = DateTime.Now;
            //hobbie.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            await DbContext.Hobbies.AddAsync(hobbie);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Kurs başarıyla güncellendi.", hobbie);
        }
        

        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<Hobbie> query = DbContext.Set<Hobbie>().Include(a => a).Include(a => a.UserProfile).ThenInclude(a => a.User).AsNoTracking();
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
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<Hobbie>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var hobbie = await DbContext.Hobbies.SingleOrDefaultAsync(a => a.ID == id);
            if (hobbie is null)
                return new DataResult(ResultStatus.Error, "Böyle bir hobi bulunamadı");
            return new DataResult(ResultStatus.Success, hobbie);
        }

        public async Task<IDataResult> GetAllByProfileIdAsync(int id)
        {
            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == id);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");
            var hobbies = DbContext.Hobbies.Where(a => a.UserProfileID == id).Include(a => a.UserProfile);
            if (hobbies.Count() < 1)
                return new DataResult(ResultStatus.Error, "Bu kullanıcıya ait bir kurs bulunamadı");
            return new DataResult(ResultStatus.Success, hobbies);
        }

        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var hobbie = await DbContext.Hobbies.SingleOrDefaultAsync(a => a.ID == id);
            if (hobbie is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kurs bulunmuyor");
            hobbie.ModifiedDate = DateTime.Now;
            hobbie.IsActive = false;
            hobbie.IsDeleted = true;
            DbContext.Hobbies.Update(hobbie);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Hobi kısmı başarı ile arşivlendi", hobbie);
        }
        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var hobbie = await DbContext.Hobbies.SingleOrDefaultAsync(a => a.ID == id);
            if (hobbie is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kurs bulunmuyor");
          
            DbContext.Hobbies.Remove(hobbie);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Hobi kısmı başarı ile arşivlendi", hobbie);
        }

    }
}
