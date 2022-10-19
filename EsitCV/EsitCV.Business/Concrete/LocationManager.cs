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
using EsitCV.Entities.Dtos.LocationDtos;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using EsitCV.Business.ValidationRules.FluentValidation.LocationValidators;
using Microsoft.EntityFrameworkCore;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace EsitCV.Business.Concrete
{
    public class LocationManager : ManagerBase, ILocationService
    {
        IHttpContextAccessor _httpContextAccessor;
        public LocationManager(EsitCVContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult> AddAsync(LocationAddDto locationAddDto)
        {
            ValidationTool.Validate(new LocationAddDtoValidator(), locationAddDto);

            var companyIsExist = await DbContext.Companies.SingleOrDefaultAsync(a => a.ID == locationAddDto.CompanyID);
            if (companyIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir şirket bulunamadı");

            var location = Mapper.Map<Location>(locationAddDto);
            location.CreatedDate = DateTime.Now;
            //location.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            location.CompanyID = companyIsExist.ID;
            location.Company = companyIsExist;

            await DbContext.Locations.AddAsync(location);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Şirket lokasyonu başarıyla eklendi.", location);
        }

        public async Task<IDataResult> UpdateAsync(LocationUpdateDto locationUpdateDto)
        {
            ValidationTool.Validate(new LocationUpdateDtoValidator(), locationUpdateDto);

            var locationIsExist = await DbContext.Locations.SingleOrDefaultAsync(a => a.ID == locationUpdateDto.ID);
            if (locationIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir lokasyon bulunamadı");

            var location = Mapper.Map<Location>(locationUpdateDto);
            location.ModifiedDate = DateTime.Now;
            //location.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            DbContext.Locations.Update(location);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "İş ilanı başarıyla güncellendi.", location);
        }

       
        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<Location> query = DbContext.Set<Location>().Include(a => a.Company).AsNoTracking();
            if (isDeleted.HasValue)
                query = query.Where(a => a.IsActive == isDeleted);
            switch (orderBy)
            {
                case OrderBy.Id:
                    query = isAscending ? query.OrderBy(a => a.ID) : query.OrderByDescending(a => a.ID);
                    break;
                case OrderBy.Az:
                    query = isAscending ? query.OrderBy(a => a.Company.Name) : query.OrderByDescending(a => a.Company.Name);
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
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<Location>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByCompanyIdAsync(int id)
        {
            var location = await DbContext.Locations.SingleOrDefaultAsync(a => a.CompanyID == id);
            if (location is null)
                return new DataResult(ResultStatus.Wrong, "böyle bir lokasyon bulunamadı");
            return new DataResult(ResultStatus.Success, location);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var location = await DbContext.Locations.SingleOrDefaultAsync(a => a.ID == id);
            if (location is null)
                return new DataResult(ResultStatus.Wrong, "böyle bir lokasyon bulunamadı");
            return new DataResult(ResultStatus.Success, location);
        }


        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var location = await DbContext.Locations.SingleOrDefaultAsync(a => a.ID == id);
            if (location is not null)
                return new DataResult(ResultStatus.Wrong, "böyle bir lokasyon bulunamadı");

            location.ModifiedDate = DateTime.Now;
            //location.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);
            location.IsActive = false;
            location.IsDeleted = true;

            DbContext.Locations.Update(location);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Lokasyon başarıyla arşivlendi", location);
        }
  
        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var location = await DbContext.Locations.SingleOrDefaultAsync(a => a.ID == id);
            if (location is not null)
                return new DataResult(ResultStatus.Wrong, "böyle bir lokasyon bulunamadı");

         
            DbContext.Locations.Remove(location);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Lokasyon başarıyla silindi", location);
        }

      
    }
}
