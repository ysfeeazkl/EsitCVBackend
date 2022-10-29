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
using EsitCV.Entities.Dtos.FeaturesDtos.OrganizationDtos;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.CourseValidators;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using Microsoft.EntityFrameworkCore;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.OrganizationValidators;
using Microsoft.AspNetCore.Http;

namespace EsitCV.Business.Concrete
{
    public class OrganizationManager : ManagerBase, IOrganizationService
    {
        IHttpContextAccessor _httpContextAccessor;

        public OrganizationManager(EsitCVContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult> AddAsync(OrganizationAddDto organizationAddDto)
        {
            ValidationTool.Validate(new OrganizationAddDtoValidator(), organizationAddDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == organizationAddDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var organization = Mapper.Map<Organization>(organizationAddDto);
            organization.CreatedDate = DateTime.Now;
            organization.UserProfile = userProfileIsExist;
            //organization.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            await DbContext.Organizations.AddAsync(organization);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Organizasyon başarıyla Eklendi.", organization);
        }
        public async Task<IDataResult> UpdateAsync(OrganizationUpdateDto organizationUpdateDto)
        {
            ValidationTool.Validate(new OrganizationUpdateDtoValidator(), organizationUpdateDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == organizationUpdateDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var organization = Mapper.Map<Organization>(organizationUpdateDto);
            organization.ModifiedDate = DateTime.Now;
            //organization.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            DbContext.Organizations.Update(organization);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Organizasyon başarıyla güncellendi.", organization);
        }

        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<Organization> query = DbContext.Set<Organization>().Include(a => a).Include(a => a.UserProfile).ThenInclude(a => a.User).AsNoTracking();
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
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<Organization>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var organization = await DbContext.Organizations.SingleOrDefaultAsync(a => a.ID == id);
            if (organization is null)
                return new DataResult(ResultStatus.Error, "Böyle bir organizasyon bulunamadı");
            return new DataResult(ResultStatus.Success, organization);
        }

        public async Task<IDataResult> GetAllByProfileIdAsync(int id)
        {
            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == id);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");
            var organizations = DbContext.Organizations.Where(a => a.UserProfileID == id).Include(a => a.UserProfile);
            if (organizations.Count() < 1)
                return new DataResult(ResultStatus.Error, "Bu kullanıcıya ait bir organizasyon bulunamadı");
            return new DataResult(ResultStatus.Success, organizations);
        }
        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var organization = await DbContext.Courses.SingleOrDefaultAsync(a => a.ID == id);
            if (organization is null)
                return new DataResult(ResultStatus.Error, "Böyle bir organizasyon bulunmuyor");
            organization.ModifiedDate = DateTime.Now;
            organization.IsActive = false;
            organization.IsDeleted = true;
            DbContext.Courses.Update(organization);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Organizasyon başarı ile arşivlendi", organization);
        }
        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var organization = await DbContext.Courses.SingleOrDefaultAsync(a => a.ID == id);
            if (organization is null)
                return new DataResult(ResultStatus.Error, "Böyle bir organizasyon bulunmuyor");
            DbContext.Courses.Remove(organization);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Kurs kısmı başarı ile silindi", organization);
        }

      
    }
}
