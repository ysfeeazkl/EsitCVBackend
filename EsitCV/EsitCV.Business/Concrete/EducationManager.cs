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
using EsitCV.Entities.Dtos.FeaturesDtos.EducationDtos;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.CourseValidators;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using Microsoft.EntityFrameworkCore;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.EducationValidators;

namespace EsitCV.Business.Concrete
{
    public class EducationManager : ManagerBase, IEducationService
    {
        public EducationManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {

        }

        public async Task<IDataResult> AddAsync(EducationAddDto educationAddDto)
        {
            ValidationTool.Validate(new EducationAddDtoValidator(), educationAddDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == educationAddDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var education = Mapper.Map<Education>(educationAddDto);
            education.CreatedDate = DateTime.Now;
            education.UserProfile = userProfileIsExist;
            //education.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            await DbContext.Educations.AddAsync(education);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Eğitim başarıyla Eklendi.", education);
        }
        public async Task<IDataResult> UpdateAsync(EducationUpdateDto educationUpdateDto)
        {
            ValidationTool.Validate(new EducationUpdateDtoValidator(), educationUpdateDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == educationUpdateDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var education = Mapper.Map<Education>(educationUpdateDto);
            education.CreatedDate = DateTime.Now;
            //education.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            DbContext.Educations.Update(education);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Eğitim başarıyla güncellendi.", education);
        }


        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<Education> query = DbContext.Set<Education>().Include(a => a).Include(a => a.UserProfile).ThenInclude(a => a.User).AsNoTracking();
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
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<Education>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var education = await DbContext.Educations.SingleOrDefaultAsync(a => a.ID == id);
            if (education is null)
                return new DataResult(ResultStatus.Error, "Böyle bir eğitim bilgisi bulunamadı");
            return new DataResult(ResultStatus.Success, education);
        }

        public async Task<IDataResult> GetAllByProfileIdAsync(int id)
        {
            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == id);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");
            var educations = DbContext.Educations.Where(a => a.UserProfileID == id).Include(a => a.UserProfile);
            if (educations.Count() < 1)
                return new DataResult(ResultStatus.Error, "Bu kullanıcıya ait bir eiğitim  bulunamadı");
            return new DataResult(ResultStatus.Success, educations);
        }

        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var education = await DbContext.Educations.SingleOrDefaultAsync(a => a.ID == id);
            if (education is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kurs bulunmuyor");
            education.ModifiedDate = DateTime.Now;
            education.IsActive = false;
            education.IsDeleted = true;
            DbContext.Educations.Update(education);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Eiğitm kısmı başarı ile arşivlendi", education);
        }

        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var education = await DbContext.Educations.SingleOrDefaultAsync(a => a.ID == id);
            if (education is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kurs bulunmuyor");
          
            DbContext.Educations.Remove(education);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Eiğitm kısmı başarı ile silindi", education);
        }


    }
}
