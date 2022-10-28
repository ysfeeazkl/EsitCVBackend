using EsitCV.Entities.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Business.Abstract;
using EsitCV.Business.Utilities;
using AutoMapper;
using EsitCV.Data.Concrete.Context;
using EsitCV.Entities.Dtos.FeaturesDtos.AreasOfInterestDtos;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.AboutValidators;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.AboutDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using Microsoft.EntityFrameworkCore;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.AreasOfInterestValidators;

namespace EsitCV.Business.Concrete
{
    public class AreasOfInterestManager: ManagerBase, IAreasOfInterestService
    {
        public AreasOfInterestManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {
                
        }

        public async Task<IDataResult> AddAsync(AreasOfInterestAddDto areasOfInterestAddDto)
        {
            ValidationTool.Validate(new AreasOfInterestAddDtoValidator(), areasOfInterestAddDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == areasOfInterestAddDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var areasOfInterest = Mapper.Map<AreasOfInterest>(areasOfInterestAddDto);
            areasOfInterest.CreatedDate = DateTime.Now;
            //areasOfInterest.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            await DbContext.AreasOfInterests.AddAsync(areasOfInterest);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "İlgili alan başarıyla Eklendi.", areasOfInterest);
        }

        public async Task<IDataResult> UpdateAsync(AreasOfInterestUpdateDto areasOfInterestUpdateDto)
        {
            ValidationTool.Validate(new AreasOfInterestUpdateDtoValidator(), areasOfInterestUpdateDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == areasOfInterestUpdateDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");
         
            var areasOfInterest = Mapper.Map<AreasOfInterest>(areasOfInterestUpdateDto);
            areasOfInterest.CreatedDate = DateTime.Now;
            //areasOfInteres.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            DbContext.AreasOfInterests.Update(areasOfInterest);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "İlgi alanı kısımı başarıyla Güncellendi.", areasOfInterest);
        }



        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<AreasOfInterest> query = DbContext.Set<AreasOfInterest>().Include(a => a).Include(a => a.UserProfile).ThenInclude(a => a.User).AsNoTracking();
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
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<AreasOfInterest>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var areasOfInterestIsExist = await DbContext.AreasOfInterests.SingleOrDefaultAsync(a => a.ID == id);
            if (areasOfInterestIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir ilgi alanı bulunamadı");
            return new DataResult(ResultStatus.Success, areasOfInterestIsExist);
        }

        public async Task<IDataResult> GetAllByProfileIdAsync(int id)
        {
            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == id);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");
            var areasOfInterestIsExist =  DbContext.AreasOfInterests.Where(a => a.UserProfileID == id).Include(a=>a.UserProfile);
            if (areasOfInterestIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir ilgi alanı bulunamadı");
            return new DataResult(ResultStatus.Success, areasOfInterestIsExist);
        }


        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var areasOfInterest = await DbContext.AreasOfInterests.SingleOrDefaultAsync(a => a.ID == id);
            if (areasOfInterest is null)
                return new DataResult(ResultStatus.Error, "Böyle bir ilgi alanı bulunmuyor");
            areasOfInterest.ModifiedDate = DateTime.Now;
            areasOfInterest.IsActive = false;
            areasOfInterest.IsDeleted = true;
            DbContext.AreasOfInterests.Update(areasOfInterest);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "İlgi alanı kısmı başarı ile arşivlendi", areasOfInterest);
        }
        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var areasOfInterest = await DbContext.AreasOfInterests.SingleOrDefaultAsync(a => a.ID == id);
            if (areasOfInterest is null)
                return new DataResult(ResultStatus.Error, "Böyle bir ilgi alanı bulunmuyor");
           
            DbContext.AreasOfInterests.Remove(areasOfInterest);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "İlgi alanı kısmı başarı ile silindi", areasOfInterest);
        }

      
    }
}
