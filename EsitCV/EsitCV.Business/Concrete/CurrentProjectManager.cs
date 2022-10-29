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
using EsitCV.Entities.Dtos.FeaturesDtos.CurrentProjectDtos;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.CourseValidators;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using Microsoft.EntityFrameworkCore;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.CurrentProjectValidators;

namespace EsitCV.Business.Concrete
{
    public class CurrentProjectManager: ManagerBase, ICurrentProjectService
    {
        public CurrentProjectManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {

        }

        public async Task<IDataResult> AddAsync(CurrentProjectAddDto currentProjectAddDto)
        {
            ValidationTool.Validate(new CurrentProjectAddDtoValidator(), currentProjectAddDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == currentProjectAddDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var currentProject = Mapper.Map<CurrentProject>(currentProjectAddDto);
            currentProject.CreatedDate = DateTime.Now;
            currentProject.UserProfile = userProfileIsExist;
            //currentProject.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            await DbContext.CurrentProjects.AddAsync(currentProject);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Proje başarıyla Eklendi.", currentProject);
        }

        public async Task<IDataResult> UpdateAsync(CurrentProjectUpdateDto currentProjectUpdateDto)
        {
            ValidationTool.Validate(new CurrentProjectUpdateDtoValidator(), currentProjectUpdateDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == currentProjectUpdateDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var currentProject = Mapper.Map<CurrentProject>(currentProjectUpdateDto);
            currentProject.CreatedDate = DateTime.Now;
            //currentProject.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            DbContext.CurrentProjects.Update(currentProject);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Proje kısımı başarıyla Güncellendi.", currentProject);
        }
      

        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<CurrentProject> query = DbContext.Set<CurrentProject>().Include(a => a).Include(a => a.UserProfile).ThenInclude(a => a.User).AsNoTracking();
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
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<CurrentProject>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var currentProject = await DbContext.CurrentProjects.SingleOrDefaultAsync(a => a.ID == id);
            if (currentProject is null)
                return new DataResult(ResultStatus.Error, "Böyle bir proje bulunamadı");
            return new DataResult(ResultStatus.Success, currentProject);
        }

        public async Task<IDataResult> GetAllByProfileIdAsync(int id)
        {
            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == id);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");
            var currentProjects = DbContext.CurrentProjects.Where(a => a.UserProfileID == id).Include(a => a.UserProfile);
            if (currentProjects.Count() < 1)
                return new DataResult(ResultStatus.Error, "Bu kullanıcıya ait bir proje bulunamadı");
            return new DataResult(ResultStatus.Success, currentProjects);
        }

        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var currentProject = await DbContext.CurrentProjects.SingleOrDefaultAsync(a => a.ID == id);
            if (currentProject is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kurs bulunmuyor");
            currentProject.ModifiedDate = DateTime.Now;
            currentProject.IsActive = false;
            currentProject.IsDeleted = true;
            DbContext.CurrentProjects.Update(currentProject);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "proje kısmı başarı ile arşivlendi", currentProject);
        }

        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var currentProject = await DbContext.CurrentProjects.SingleOrDefaultAsync(a => a.ID == id);
            if (currentProject is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kurs bulunmuyor");
            
            DbContext.CurrentProjects.Remove(currentProject);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "proje kısmı başarı ile silindi", currentProject);
        }

       
    }
}
