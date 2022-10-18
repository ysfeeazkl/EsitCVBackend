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
using EsitCV.Entities.Dtos.UserDisabilityDtos;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using EsitCV.Business.ValidationRules.FluentValidation.UserAndDisabilityValidators;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using EsitCV.Entities.Concrete;

namespace EsitCV.Business.Concrete
{
    public class UserAndDisabilityManager : ManagerBase, IUserAndDisabilityService
    {
        IHttpContextAccessor _httpContextAccessor;
        public UserAndDisabilityManager(EsitCVContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult> AddAsync(UserAndDisabilityAddDto userAndDisabilityAddDto)
        {
            ValidationTool.Validate(new UserAndDisabilityAddDtoValidator(), userAndDisabilityAddDto);

            var userAndDisabiltyIsExist = await DbContext.UserAndDisabilities.SingleOrDefaultAsync(ud => ud.UserID == userAndDisabilityAddDto.UserID && ud.DisabilityID == userAndDisabilityAddDto.DisabilityID);
            if (userAndDisabiltyIsExist is not null)
                return new DataResult(ResultStatus.Error, "Böyle bir eşleşme zaten var");

            var disability = await DbContext.Disabilities.SingleOrDefaultAsync(g => g.ID == userAndDisabilityAddDto.DisabilityID);
            if (disability is null)
                return new DataResult(ResultStatus.Error, Messages.General.NotFoundArgument("Engel"));

            var user = await DbContext.Users.SingleOrDefaultAsync(c => c.ID == userAndDisabilityAddDto.UserID);
            if (user is null)
                return new DataResult(ResultStatus.Error, Messages.General.NotFoundArgument("Kullanıcı"));

            var userAndDisability = Mapper.Map<UserAndDisability>(userAndDisabilityAddDto);

            userAndDisability.User = user;
            userAndDisability.User = user;
            userAndDisability.User.ModifiedDate = DateTime.Now;
            //userAndDisability.User.ModifiedByUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(a => a.Type == "UserId").Value);

            userAndDisability.Disability = disability;
            user.UserAndDisabilities.Add(userAndDisability);
            disability.UserAndDisabilities.Add(userAndDisability);

            await DbContext.UserAndDisabilities.AddAsync(userAndDisability);
            await DbContext.SaveChangesAsync();

            return new DataResult(ResultStatus.Success, $"{disability.Name} isimli engel durumu,{user.FirstName} isimli kullanıcıya eklendi", userAndDisability);
        }

        public async Task<IDataResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            IQueryable<UserAndDisability> query = DbContext.Set<UserAndDisability>().Include(a => a.User).Include(a=>a.Disability).AsNoTracking();
            if (isDeleted.HasValue)
                query = query.Where(a => a.IsActive == isDeleted);
            switch (orderBy)
            {
                case OrderBy.Id:
                    query = isAscending ? query.OrderBy(a => a.ID) : query.OrderByDescending(a => a.ID);
                    break;
                case OrderBy.Az:
                    query = isAscending ? query.OrderBy(a => a.User.FirstName) : query.OrderByDescending(a => a.User.FirstName);
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
                var filteredQuery = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => Mapper.Map<UserAndDisability>(a)).ToListAsync();
                return new DataResult(ResultStatus.Success, filteredQuery);
            }
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetAllByDisabilityIdAsync(int disabilityID, bool inculudeDisability)
        {
            if (disabilityID < 1)
                return new DataResult(ResultStatus.Error, "Geçersiz Parametre");
            IQueryable<UserAndDisability> query = DbContext.Set<UserAndDisability>().Include(a => a.User).Where(a => a.DisabilityID == disabilityID);
            if (inculudeDisability) query = query.Include(a => a.Disability);
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> GetAllByUserIdAsync(int userID, bool inculudeUser)
        {
            if (userID < 1)
                return new DataResult(ResultStatus.Error, "Geçersiz Parametre");
            IQueryable<UserAndDisability> query = DbContext.Set<UserAndDisability>().Include(a => a.Disability).Where(a => a.UserID == userID);
            if (inculudeUser) query = query.Include(a => a.Disability);
            return new DataResult(ResultStatus.Success, query);
        }

        public async Task<IDataResult> DeleteByUserIdAndDisabilityIdAsync(int userID, int disabilityID)
        {
            var userAndDisability = await DbContext.UserAndDisabilities.SingleOrDefaultAsync(a => a.UserID == userID && a.DisabilityID == disabilityID);
            if (userAndDisability is null)
                return new DataResult(ResultStatus.Error, Messages.General.NotFoundArgument("Böyle bir engel ve kullanıcı eşleşmesi bulunamadı."));
            DbContext.UserAndDisabilities.Remove(userAndDisability);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, $"başarıyla silindi.", userAndDisability);
        }
    }
}
