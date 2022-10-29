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
using EsitCV.Entities.Dtos.FeaturesDtos.LicenseOrCertificateDtos;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.CourseValidators;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using Microsoft.EntityFrameworkCore;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.LicenseOrCertificateValidators;
using Microsoft.AspNetCore.Http;

namespace EsitCV.Business.Concrete
{
    public class LicenseOrCertificateManager : ManagerBase, ILicenseOrCertificateService
    {
        IHttpContextAccessor _httpContextAccessor;

        public LicenseOrCertificateManager(EsitCVContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult> AddAsync(LicenseOrCertificateAddDto licenseOrCertificateAddDto)
        {
            ValidationTool.Validate(new LicenseOrCertificateAddDtoValidator(), licenseOrCertificateAddDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == licenseOrCertificateAddDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var licenseOrCertificate = Mapper.Map<LicenseOrCertificate>(licenseOrCertificateAddDto);
            licenseOrCertificate.CreatedDate = DateTime.Now;
            licenseOrCertificate.UserProfile = userProfileIsExist;
            //licenseOrCertificate.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            await DbContext.LicenseOrCertificates.AddAsync(licenseOrCertificate);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Lisans veya Sertifika başarıyla Eklendi.", licenseOrCertificate);
        }
        public async Task<IDataResult> UpdateAsync(LicenseOrCertificateUpdateDto licenseOrCertificateUpdateDto)
        {
            ValidationTool.Validate(new LicenseOrCertificateUpdateDtoValidator(), licenseOrCertificateUpdateDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == licenseOrCertificateUpdateDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var licenseOrCertificate = Mapper.Map<LicenseOrCertificate>(licenseOrCertificateUpdateDto);
            licenseOrCertificate.ModifiedDate = DateTime.Now;
            //licenseOrCertificate.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            DbContext.LicenseOrCertificates.Remove(licenseOrCertificate);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Lisans veya Sertifika başarıyla güncellendi.", licenseOrCertificate);
        }

        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<LicenseOrCertificate> query = DbContext.Set<LicenseOrCertificate>().Include(a => a).Include(a => a.UserProfile).ThenInclude(a => a.User).AsNoTracking();
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
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<LicenseOrCertificate>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var licenseOrCertificate = await DbContext.LicenseOrCertificates.SingleOrDefaultAsync(a => a.ID == id);
            if (licenseOrCertificate is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Lisans veya Sertifika  bulunamadı");
            return new DataResult(ResultStatus.Success, licenseOrCertificate);
        }

        public async Task<IDataResult> GetAllByProfileIdAsync(int id)
        {
            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == id);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");
            var licenseOrCertificates = DbContext.LicenseOrCertificates.Where(a => a.UserProfileID == id).Include(a => a.UserProfile);
            if (licenseOrCertificates.Count() < 1)
                return new DataResult(ResultStatus.Error, "Bu kullanıcıya ait bir lisans veya sertifika bilgisi bulunamadı");
            return new DataResult(ResultStatus.Success, licenseOrCertificates);
        }
        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var licenseOrCertificate = await DbContext.LicenseOrCertificates.SingleOrDefaultAsync(a => a.ID == id);
            if (licenseOrCertificate is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Lisans veya sertifika bulunmuyor");
            licenseOrCertificate.ModifiedDate = DateTime.Now;
            licenseOrCertificate.IsActive = false;
            licenseOrCertificate.IsDeleted = true;
            DbContext.LicenseOrCertificates.Update(licenseOrCertificate);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Lisans veya sertifika kısmı başarı ile arşivlendi", licenseOrCertificate);
        }

        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var licenseOrCertificate = await DbContext.LicenseOrCertificates.SingleOrDefaultAsync(a => a.ID == id);
            if (licenseOrCertificate is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Lisans veya sertifika bulunmuyor");
 
            DbContext.LicenseOrCertificates.Remove(licenseOrCertificate);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Lisans veya sertifika kısmı başarı ile silindi", licenseOrCertificate);
        }

     
    }
}
