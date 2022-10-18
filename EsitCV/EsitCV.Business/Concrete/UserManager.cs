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
using EsitCV.Entities.Dtos.UserDtos;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using EsitCV.Business.ValidationRules.FluentValidation.UserValidators;
using Microsoft.EntityFrameworkCore;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace EsitCV.Business.Concrete
{
    public class UserManager : ManagerBase, IUserService
    {
        IHttpContextAccessor _httpContextAccessor;
        public UserManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {

        }
        public async Task<IDataResult> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            ValidationTool.Validate(new UserUpdateDtoValidator(), userUpdateDto);

            var userIsExist = await DbContext.Companies.SingleOrDefaultAsync(a => a.ID == userUpdateDto.ID);
            if (userIsExist is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kullanıcı bulunamadı");

            var user = Mapper.Map<User>(userUpdateDto);
            user.ModifiedDate = DateTime.Now;
            //user.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            DbContext.Users.Update(user);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "Kullanıcı başarıyla güncellendi.", user);
        }
        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<User> query = DbContext.Set<User>().AsNoTracking();
            if (isDeleted.HasValue)
                query = query.Where(a => a.IsActive == isDeleted);
            switch (orderBy)
            {
                case OrderBy.Id:
                    query = isAscending ? query.OrderBy(a => a.ID) : query.OrderByDescending(a => a.ID);
                    break;
                case OrderBy.Az:
                    query = isAscending ? query.OrderBy(a => a.FirstName) : query.OrderByDescending(a => a.FirstName);
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
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<User>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetByIdAsync(int id)
        {
            var user = await DbContext.Users.SingleOrDefaultAsync(a => a.ID == id);
            if (user is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kullanıcı bulunamadı");
            return new DataResult(ResultStatus.Success, user);
        }

        public async Task<IDataResult> DeleteByIdAsync(int id)
        {
            var user = await DbContext.Users.SingleOrDefaultAsync(a => a.ID == id);
            if (user is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kullanıcı bulunmuyor");

            user.ModifiedDate = DateTime.Now;
            user.IsActive = false;
            user.IsDeleted = true;

            DbContext.Users.Update(user);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "kullanıcı başarı ile arşivlendi");
        }
        public async Task<IDataResult> HardDeleteByIdAsync(int id)
        {
            var user = await DbContext.Users.SingleOrDefaultAsync(a => a.ID == id);
            if (user is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kullanıcı bulunmuyor");

            DbContext.Users.Remove(user);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, "kullanıcı başarı ile arşivlendi");
        }
    }
}
