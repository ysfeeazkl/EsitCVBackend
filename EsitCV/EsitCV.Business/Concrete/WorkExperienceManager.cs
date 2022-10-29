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
using EsitCV.Entities.Dtos.FeaturesDtos.WorkExperienceDtos;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.CourseValidators;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using Microsoft.EntityFrameworkCore;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.WorkExperienceValidators;
using Microsoft.AspNetCore.Http;

namespace EsitCV.Business.Concrete
{
    public class WorkExperienceManager: ManagerBase, IWorkExperienceService
    {
        IHttpContextAccessor _httpContextAccessor;

        public WorkExperienceManager(EsitCVContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult> AddAsync(WorkExperienceAddDto workExperienceAddDto)
        {
            ValidationTool.Validate(new WorkExperienceAddDtoValidator(), workExperienceAddDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == workExperienceAddDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var workExperience = Mapper.Map<WorkExperience>(workExperienceAddDto);
            workExperience.CreatedDate = DateTime.Now;
            workExperience.UserProfile = userProfileIsExist;
            //workExperience.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            await DbContext.WorkExperiences.AddAsync(workExperience);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "İş deneyimi başarıyla Eklendi.", workExperience);
        }
        public async Task<IDataResult> UpdateAsync(WorkExperienceUpdateDto workExperienceUpdateDto)
        {
            ValidationTool.Validate(new WorkExperienceUpdateDtoValidator(), workExperienceUpdateDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == workExperienceUpdateDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var workExperience = Mapper.Map<WorkExperience>(workExperienceUpdateDto);
            workExperience.ModifiedDate = DateTime.Now;
            //workExperience.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            DbContext.WorkExperiences.Update(workExperience);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "İş deneyimi başarıyla güncellendi.", workExperience);
        }

       
        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<WorkExperience> query = DbContext.Set<WorkExperience>().Include(a => a).Include(a => a.UserProfile).ThenInclude(a => a.User).AsNoTracking();
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
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<WorkExperience>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var workExperience = await DbContext.WorkExperiences.SingleOrDefaultAsync(a => a.ID == id);
            if (workExperience is null)
                return new DataResult(ResultStatus.Error, "Böyle bir iş tecrübesi bulunamadı");
            return new DataResult(ResultStatus.Success, workExperience);
        }

        public async Task<IDataResult> GetAllByProfileIdAsync(int id)
        {
            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == id);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");
            var workExperiences = DbContext.WorkExperiences.Where(a => a.UserProfileID == id).Include(a => a.UserProfile);
            if (workExperiences.Count() < 1)
                return new DataResult(ResultStatus.Error, "Bu kullanıcıya ait bir iş deneyimi bulunamadı");
            return new DataResult(ResultStatus.Success, workExperiences);
        }

        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var workExperience = await DbContext.WorkExperiences.SingleOrDefaultAsync(a => a.ID == id);
            if (workExperience is null)
                return new DataResult(ResultStatus.Error, "Böyle bir iş deneyimi bulunmuyor");
            workExperience.ModifiedDate = DateTime.Now;
            workExperience.IsActive = false;
            workExperience.IsDeleted = true;
            DbContext.WorkExperiences.Update(workExperience);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "İş deneyimi kısmı başarı ile arşivlendi", workExperience);
        }


        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var workExperience = await DbContext.WorkExperiences.SingleOrDefaultAsync(a => a.ID == id);
            if (workExperience is null)
                return new DataResult(ResultStatus.Error, "Böyle bir iş deneyimi bulunmuyor");
            DbContext.WorkExperiences.Remove(workExperience);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "İş deneyimi kısmı başarı ile silindi", workExperience);
        }


      
    }
}
