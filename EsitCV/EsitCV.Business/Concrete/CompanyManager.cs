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
using EsitCV.Entities.Dtos.CompanyDtos;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using EsitCV.Business.ValidationRules.FluentValidation.CompanyValidators;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using EsitCV.Entities.Concrete;

namespace EsitCV.Business.Concrete
{
    public class CompanyManager: ManagerBase, ICompanyService
    {
        IHttpContextAccessor _httpContextAccessor;
        public CompanyManager(EsitCVContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, context)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IDataResult> UpdateAsync(CompanyUpdateDto companyUpdateDto)
        {
            ValidationTool.Validate(new CompanyUpdateDtoValidator(), companyUpdateDto);

            var companyIsExist = await DbContext.Companies.SingleOrDefaultAsync(a => a.ID == companyUpdateDto.ID);
            if (companyIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir şirket bulunamadı");

            var company = Mapper.Map<Company>(companyUpdateDto);
            company.ModifiedDate = DateTime.Now;
            //company.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            DbContext.Companies.Update(company);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Şirket başarıyla güncellendi.", company);
        }


        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<Company> query = DbContext.Set<Company>().AsNoTracking();
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
                    query = isAscending ? query.OrderBy(a => a.ID) : query.OrderByDescending(a => a.ID);
                    break;
            }

            if (currentPage != 0 && pageSize != 0)
            {
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<Company>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var company = await DbContext.Companies.SingleOrDefaultAsync(a => a.ID == id);
            if (company is null)
                return new DataResult(ResultStatus.Error, "Böyle bir şirket bulunamadı");
            return new DataResult(ResultStatus.Success, company);
        }
        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var company = await DbContext.Companies.SingleOrDefaultAsync(a => a.ID == id);
            if (company is null)
                return new DataResult(ResultStatus.Error, "Böyle bir şirket bulunmuyor");

            company.ModifiedDate = DateTime.Now;
            company.IsActive = false;
            company.IsDeleted = true;

            DbContext.Companies.Update(company);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "şirket başarı ile arşivlendi");
        }
        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var company = await DbContext.Companies.SingleOrDefaultAsync(a => a.ID == id);
            if (company is null)
                return new DataResult(ResultStatus.Error, "Böyle bir şirket bulunmuyor");

            DbContext.Companies.Remove(company);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "şirket başarı ile silindi");
        }

        
    }
}
