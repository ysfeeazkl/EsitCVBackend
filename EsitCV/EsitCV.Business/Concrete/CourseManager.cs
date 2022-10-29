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
using EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.AreasOfInterestValidators;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.AreasOfInterestDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using Microsoft.EntityFrameworkCore;
using EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.CourseValidators;

namespace EsitCV.Business.Concrete
{
    public class CourseManager: ManagerBase, ICourseService
    {
        public CourseManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {

        }

        public async Task<IDataResult> AddAsync(CourseAddDto courseAddDto)
        {
            ValidationTool.Validate(new CourseAddDtoValidator(), courseAddDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == courseAddDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var course = Mapper.Map<Course>(courseAddDto);
            course.CreatedDate = DateTime.Now;
            course.UserProfile = userProfileIsExist;
            //course.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            await DbContext.Courses.AddAsync(course);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Kurs başarıyla Eklendi.", course);
        }

        public async Task<IDataResult> UpdateAsync(CourseUpdateDto courseUpdateDto)
        {
            ValidationTool.Validate(new CourseUpdateDtoValidator(), courseUpdateDto);

            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == courseUpdateDto.UserProfileID);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");

            var course = Mapper.Map<Course>(courseUpdateDto);
            course.CreatedDate = DateTime.Now;
            //course.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            DbContext.Courses.Update(course);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Kurs kısımı başarıyla Güncellendi.", course);
        }

       

        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<Course> query = DbContext.Set<Course>().Include(a => a).Include(a => a.UserProfile).ThenInclude(a => a.User).AsNoTracking();
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
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<Course>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var course = await DbContext.Courses.SingleOrDefaultAsync(a => a.ID == id);
            if (course is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kurs bulunamadı");
            return new DataResult(ResultStatus.Success, course);
        }

        public async Task<IDataResult> GetAllByProfileIdAsync(int id)
        {
            var userProfileIsExist = await DbContext.UserProfiles.SingleOrDefaultAsync(a => a.ID == id);
            if (userProfileIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir Kullanıcı profili Bulunamadı");
            var courses = DbContext.Courses.Where(a => a.UserProfileID == id).Include(a => a.UserProfile);
            if (courses.Count() < 1)
                return new DataResult(ResultStatus.Error, "Bu kullanıcıya ait bir kurs bulunamadı");
            return new DataResult(ResultStatus.Success, courses);
        }

        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var course = await DbContext.Courses.SingleOrDefaultAsync(a => a.ID == id);
            if (course is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kurs bulunmuyor");
            course.ModifiedDate = DateTime.Now;
            course.IsActive = false;
            course.IsDeleted = true;
            DbContext.Courses.Update(course);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Kurs kısmı başarı ile arşivlendi", course);
        }
        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var course = await DbContext.Courses.SingleOrDefaultAsync(a => a.ID == id);
            if (course is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kurs bulunmuyor");
            DbContext.Courses.Remove(course);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, "Kurs kısmı başarı ile silindi", course);
        }

    
    }
}
