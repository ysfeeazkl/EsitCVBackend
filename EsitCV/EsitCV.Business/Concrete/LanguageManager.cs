using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Abstract;
using EsitCV.Business.Abstract;
using EsitCV.Business.Utilities;
using EsitCV.Data.Concrete.Context;
using AutoMapper;
using EsitCV.Entities.Dtos.FeaturesDtos.LanguageDtos;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.CourseValidators;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using Microsoft.EntityFrameworkCore;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.LanguageValidators;
using Microsoft.AspNetCore.Http;

namespace EsitCV.Business.Concrete
{
    public class LanguageManager : ManagerBase, ILanguageService
    {
        IHttpContextAccessor _httpContextAccessor;

        public LanguageManager(EsitCVContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult> AddAsync(LanguageAddDto languageAddDto)
        {
            ValidationTool.Validate(new LanguageAddDtoValidator(), languageAddDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == languageAddDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var language = Mapper.Map<Language>(languageAddDto);
            language.CreatedDate = DateTime.Now;
            language.UserProfile = userProfileIsExist;
            //language.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            await DbContext.Language.AddAsync(language);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Dil bilgisi başarıyla Eklendi.", language);
        }
        public async Task<IDataResult> UpdateAsync(LanguageUpdateDto languageUpdateDto)
        {
            ValidationTool.Validate(new LanguageUpdateDtoValidator(), languageUpdateDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == languageUpdateDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var language = Mapper.Map<Language>(languageUpdateDto);
            language.ModifiedDate = DateTime.Now;
            //language.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            DbContext.Language.Update(language);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Dil bilgisi başarıyla güncellendi.", language);
        }


        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<Language> query = DbContext.Set<Language>().Include(a => a).Include(a => a.UserProfile).ThenInclude(a => a.User).AsNoTracking();
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
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<Language>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var language = await DbContext.Language.SingleOrDefaultAsync(a => a.ID == id);
            if (language is null)
                return new DataResult(ResultStatus.Error, "Böyle bir dil bilgisi bulunamadı");
            return new DataResult(ResultStatus.Success, language);
        }

        public async Task<IDataResult> GetAllByProfileIdAsync(int id)
        {
            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == id);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");
            var languages = DbContext.Language.Where(a => a.UserProfileID == id).Include(a => a.UserProfile);
            if (languages.Count() < 1)
                return new DataResult(ResultStatus.Error, "Bu kullanıcıya ait bir dil bilgisi bulunamadı");
            return new DataResult(ResultStatus.Success, languages);

        }
        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var language = await DbContext.Language.SingleOrDefaultAsync(a => a.ID == id);
            if (language is null)
                return new DataResult(ResultStatus.Error, "Böyle bir dil bilgisi bulunmuyor");
            language.ModifiedDate = DateTime.Now;
            language.IsActive = false;
            language.IsDeleted = true;
            DbContext.Language.Update(language);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Dil bilgisi kısmı başarı ile arşivlendi", language);
        }
        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var language = await DbContext.Language.SingleOrDefaultAsync(a => a.ID == id);
            if (language is null)
                return new DataResult(ResultStatus.Error, "Böyle bir dil bilgisi bulunmuyor");
            DbContext.Language.Remove(language);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Dil bilgisi kısmı başarı ile silindi", language);
        }

      
    }
}
