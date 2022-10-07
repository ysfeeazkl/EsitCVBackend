using AutoMapper;
using EsitCV.Business.Abstract;
using EsitCV.Business.AbstractUtilities;
using EsitCV.Business.Utilities;
using EsitCV.Data.Concrete.Context;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.AuthDtos;
using EsitCV.Shared.Utilities.Results.Abstract;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.Concrete
{
    public class AuthManager : ManagerBase, IAuthService
    {
        IJwtHelper _jwtHelper;
        IHttpContextAccessor _httpContextAccessor;
        public AuthManager(EsitCVContext context, IMapper mapper, IJwtHelper jwtHelper, IHttpContextAccessor httpContextAccessor) : base(mapper, context)
        {
            _jwtHelper = jwtHelper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IDataResult> CompanyLoginWithEmailAsync(CompanyLoginWithEmailDto CompanyLoginWithEmailDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult> UserLoginWithEmailAsync(UserLoginWithEmailDto UserLoginWithEmailDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult> CompanyRegisterAsync(CompanyRegisterDto companyRegisterDto)
        {
            throw new NotImplementedException();
        }      

        public async Task<IDataResult> UserRegisterAsync(UserRegisterDto userRegisterDto)
        {
            throw new NotImplementedException();
        }

        public async Task<AccessToken> CreateAccessTokenForUserAsync(User user, bool isRefresh)
        {
            var claims = await GetUserClaimsAsync(user);
            var accessToken = _jwtHelper.CreateTokenForUser(user, claims, isRefresh);
            return accessToken;
        }

        public async Task<AccessToken> CreateAccessTokenForCompanyAsync(Company company, bool isRefresh)
        {
            var claims = await GetCompanyClaimsAsync(company);
            var accessToken = _jwtHelper.CreateTokenForCompany(company, claims, isRefresh);
            return accessToken;
        }

        public async Task<IDataResult> CreateAccessTokenByCompanyIdAsync(int companyId, bool isRefresh)
        {
            var customer = await DbContext.Companies.SingleOrDefaultAsync(a => a.ID == companyId);
            if (customer is null)
                return new DataResult(ResultStatus.Error, "Böyle Bir Şirket Bulunamadı.");
            var claims = await GetCompanyClaimsAsync(customer);
            var accessToken = _jwtHelper.CreateTokenForCompany(customer, claims, isRefresh);
            return new DataResult(ResultStatus.Success, accessToken);
        }
        public async Task<IDataResult> CreateAccessTokenByUserIdAsync(int userId, bool isRefresh)
        {
            var user = await DbContext.Users.SingleOrDefaultAsync(a => a.ID == userId);
            if (user is null)
                return new DataResult(ResultStatus.Error, "Böyle Bir Kullanıcı Bulunamadı.");
            var claims = await GetUserClaimsAsync(user);
            var accessToken = _jwtHelper.CreateTokenForUser(user, claims, isRefresh);
            return new DataResult(ResultStatus.Success, accessToken);
        }
        public async Task<IEnumerable<OperationClaim>> GetUserClaimsAsync(User user)
        {
            var roles = await DbContext.OperationClaims.ToListAsync();
            var userRoles = DbContext.UserAndOperationClaims.Where(a => a.UserID == user.ID);
            var list = new List<OperationClaim>();
            await userRoles.ForEachAsync(a =>
            {
                var role = roles.SingleOrDefault(b => b.ID == a.OperationClaimID);
                if (role != null) list.Add(role);
            });
            return list;
        }

        public async Task<IEnumerable<OperationClaim>> GetCompanyClaimsAsync(Company company)
        {
            var roles = await DbContext.OperationClaims.ToListAsync();
            var userRoles = DbContext.CompanyAndOperationClaims.Where(a => a.CompanyID == company.ID);
            var list = new List<OperationClaim>();
            await userRoles.ForEachAsync(a =>
            {
                var role = roles.SingleOrDefault(b => b.ID == a.OperationClaimID);
                if (role != null) list.Add(role);
            });
            return list;
        }

      
    }
}
