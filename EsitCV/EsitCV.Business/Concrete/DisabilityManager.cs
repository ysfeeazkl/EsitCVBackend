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
using EsitCV.Entities.Dtos.DisabilityDtos;
using EsitCV.Business.ValidationRules.FluentValidation.DisabilityValidators;
using Microsoft.AspNetCore.Http;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using EsitCV.Entities.Concrete.Disableds;

namespace EsitCV.Business.Concrete
{
    public class DisabilityManager: ManagerBase, IDisabilityService
    {
        IHttpContextAccessor _httpContextAccessor;
        public DisabilityManager(EsitCVContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult> AddAsync(DisabilityAddDto disabilityAddDto)
        {
            ValidationTool.Validate(new DisabilityAddDtoValidator(), disabilityAddDto);

            var disabilityIsExist = await DbContext.Disabilities.SingleOrDefaultAsync(a => a.Name == disabilityAddDto.Name);
            if (disabilityIsExist is not null)
                return new DataResult(ResultStatus.Error, "Böyle bir engel zaten var");

            var disability = Mapper.Map<Disability>(disabilityAddDto);
            disability.CreatedDate = DateTime.Now;
            //jobPosting.CreatedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            await DbContext.Disabilities.AddAsync(disability);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Engel durumu başarıyla Eklendi.", disability);
        }
       

       

        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)   
        {
            IQueryable<Disability> query = DbContext.Set<Disability>().AsNoTracking();
            if (isDeleted.HasValue)
                query = query.Where(a => a.IsActive == isDeleted);
            switch (orderBy)
            {
                case OrderBy.Id:
                    query = isAscending ? query.OrderBy(a => a.ID) : query.OrderByDescending(a => a.ID);
                    break;
                case OrderBy.Az:
                    query = isAscending ? query.OrderBy(a => a.Name) : query.OrderByDescending(a => a.Name);
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
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<Disability>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var disabilityIsExist = await DbContext.Disabilities.SingleOrDefaultAsync(a => a.ID == id);
            if (disabilityIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir engel bulunamadı");
            return new DataResult(ResultStatus.Error, disabilityIsExist);
        }

        public async Task<IDataResult> GetByNameAsync(string disabilityName)
        {
            var disabilityIsExist = await DbContext.Disabilities.SingleOrDefaultAsync(a => a.Name == disabilityName);
            if (disabilityIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir engel bulunamadı");
            return new DataResult(ResultStatus.Error, disabilityIsExist);
        }
        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var disability = await DbContext.Disabilities.SingleOrDefaultAsync(a => a.ID == id);
            if (disability is null)
                return new DataResult(ResultStatus.Error, "Böyle bir engel bulunamadı");

            disability.ModifiedDate = DateTime.Now;
            //jobPosting.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);
            disability.IsActive = false;
            disability.IsDeleted = true;

            DbContext.Disabilities.Update(disability);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Engel başarıyla arşivlendi", disability);
        }

        public async Task<IDataResult> DeleteByNameAsync(string disabilityName)
        {
            var disability = await DbContext.Disabilities.SingleOrDefaultAsync(a => a.Name == disabilityName);
            if (disability is null)
                return new DataResult(ResultStatus.Error, "Böyle bir engel bulunamadı");

            disability.ModifiedDate = DateTime.Now;
            //jobPosting.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);
            disability.IsActive = false;
            disability.IsDeleted = true;

            DbContext.Disabilities.Update(disability);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Engel başarıyla arşivlendi", disability);
        }
        public async Task<IDataResult> HardDeleteByNameAsync(string disabilityName)
        {
            var disability = await DbContext.Disabilities.SingleOrDefaultAsync(a => a.Name == disabilityName);
            if (disability is null)
                return new DataResult(ResultStatus.Error, "Böyle bir engel bulunamadı");

            DbContext.Disabilities.Remove(disability);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Engel başarıyla silindi", disability);
        }


        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var disability = await DbContext.Disabilities.SingleOrDefaultAsync(a => a.ID == id);
            if (disability is null)
                return new DataResult(ResultStatus.Error, "Böyle bir engel bulunamadı");
          
            DbContext.Disabilities.Remove(disability);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Engel başarıyla silindi", disability);
        }

      
    }
}
