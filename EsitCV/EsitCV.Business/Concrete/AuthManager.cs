using AutoMapper;
using EsitCV.Business.Abstract;
using EsitCV.Business.AbstractUtilities;
using EsitCV.Business.Utilities;
using EsitCV.Business.ValidationRules.FluentValidation.AuthValidators;
using EsitCV.Data.Concrete.Context;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.AuthDtos;
using EsitCV.Entities.Dtos.CompanyDtos;
using EsitCV.Entities.Dtos.CompanyTokenDtos;
using EsitCV.Entities.Dtos.UserDtos;
using EsitCV.Entities.Dtos.UserTokenDtos;
using EsitCV.Shared.Utilities.Hashing;
using EsitCV.Shared.Utilities.Results.Abstract;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Concrete;
using EsitCV.Shared.Utilities.Security.Jwt;
using EsitCV.Shared.Utilities.Validation.FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public async Task<IDataResult> CompanyLoginWithEmailAsync(CompanyLoginWithEmailDto companyLoginWithEmailDto)
        {
            ValidationTool.Validate(new CompanyLoginWithEmailDtoValidator(), companyLoginWithEmailDto);

            var company = await DbContext.Companies.SingleOrDefaultAsync(a => a.EmailAddress == companyLoginWithEmailDto.EmailAddress);
            if (company is null)
                return new DataResult(ResultStatus.Error, "Böyle bir şirket bulunamadı");

            if (HashingHelper.VerifyPasswordHash(companyLoginWithEmailDto.Password, company.PasswordHash, company.PasswordSalt))
            {
                if (!company.IsActive)
                    return new DataResult(ResultStatus.Error, "Hesabınızı Aktif Etmek İçin Destek ile İletişime Geçiniz.");

                company.LastLogin = DateTime.Now;
                company.IpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

                var accessToken = await CreateAccessTokenForCompanyAsync(company, false);
                CompanyToken companyToken = new CompanyToken
                {
                    CompanyID = company.ID,
                    Company = company,
                    Token = accessToken.Token,
                    TokenExpiration = accessToken.TokenExpiration,
                    CreatedDate = DateTime.Now,
                    IpAddress = company.IpAddress
                };
                DbContext.Companies.Update(company);
                await DbContext.CompanyTokens.AddAsync(companyToken);
                await DbContext.SaveChangesAsync();
                var companyLoginDto = new CompanyWithTokenDto
                {
                    Company = Mapper.Map<CompanyDto>(company),
                    Token = Mapper.Map<CompanyTokenDto>(companyToken),
                };

                return new DataResult(ResultStatus.Success, $"{companyLoginDto.Company.Name} Hoşgeldiniz", companyLoginDto);
            }
            return new DataResult(ResultStatus.Error, "Lütfen bilgilerinizi kontrol ediniz.");
        }

        public async Task<IDataResult> UserLoginWithEmailAsync(UserLoginWithEmailDto userLoginWithEmailDto)
        {
            ValidationTool.Validate(new UserLoginWithEmailDtoValidator(), userLoginWithEmailDto);

            var user = await DbContext.Users.SingleOrDefaultAsync(a => a.EmailAddress == userLoginWithEmailDto.EmailAddress);
            if (user is null)
                return new DataResult(ResultStatus.Error, "Böyle bir kullanıcı bulunamadı");

            if (HashingHelper.VerifyPasswordHash(userLoginWithEmailDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                if (!user.IsActive)
                    return new DataResult(ResultStatus.Error, "Hesabınızı Aktif Etmek İçin Destek ile İletişime Geçiniz.");

                user.LastLogin = DateTime.Now;
                user.IpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

                var accessToken = await CreateAccessTokenForUserAsync(user, false);
                UserToken userToken = new UserToken
                {
                    UserID = user.ID,
                    User = user,
                    Token = accessToken.Token,
                    TokenExpiration = accessToken.TokenExpiration,
                    CreatedDate = DateTime.Now,
                    IpAddress = user.IpAddress
                };
                DbContext.Users.Update(user);
                await DbContext.UserTokens.AddAsync(userToken);
                await DbContext.SaveChangesAsync();
                var userLoginDto = new UserWithTokenDto
                {
                    User = Mapper.Map<UserDto>(user),
                    Token = Mapper.Map<UserTokenDto>(userToken),
                };

                return new DataResult(ResultStatus.Success, $"{userLoginDto.User.FirstName} Hoşgeldiniz", userLoginDto);
            }
            return new DataResult(ResultStatus.Error, "Lütfen bilgilerinizi kontrol ediniz.");
        }

        public async Task<IDataResult> CompanyRegisterAsync(CompanyRegisterDto companyRegisterDto)
        {
            ValidationTool.Validate(new CompanyRegisterDtoValidator(), companyRegisterDto);

            if (await DbContext.Companies.SingleOrDefaultAsync(a => a.PhoneNumber == companyRegisterDto.PhoneNumber || a.TaxNumber == companyRegisterDto.TaxNumber || a.EmailAddress == companyRegisterDto.EmailAddress) is not null)
                return new DataResult(ResultStatus.Error, "Bu Şirket mevcut");

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(companyRegisterDto.Password, out passwordHash, out passwordSalt);
            var company = Mapper.Map<Company>(companyRegisterDto);
            company.YearOfFoundation = DateTime.Parse(companyRegisterDto.YearOfFoundation, new CultureInfo("es-ES"));
            company.PasswordHash = passwordHash;
            company.PasswordSalt = passwordSalt;
            company.IpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            company.CreatedDate = DateTime.Now;
            company.IsActive = true;
            var accessToken = await CreateAccessTokenForCompanyAsync(company, false);
            await DbContext.Companies.AddAsync(company);
            await DbContext.SaveChangesAsync();

            CompanyToken companyToken = new CompanyToken
            {
                CompanyID = company.ID,
                Company = company,
                Token = accessToken.Token,
                TokenExpiration = accessToken.TokenExpiration,
                CreatedDate = DateTime.Now,
                IpAddress = company.IpAddress
            };
            await DbContext.CompanyTokens.AddAsync(companyToken);
            CompanyAndOperationClaim companyOperationClaim = new CompanyAndOperationClaim
            {
                CompanyID = company.ID,
                OperationClaimID = 3 //Company
            };
            await DbContext.CompanyAndOperationClaims.AddAsync(companyOperationClaim);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, $"Hoşgeldiniz {company.Name}.", new CompanyWithTokenDto
            {
                Company = Mapper.Map<CompanyDto>(company),
                Token = Mapper.Map<CompanyTokenDto>(companyToken),
            });
        }      

        public async Task<IDataResult> UserRegisterAsync(UserRegisterDto userRegisterDto)
        {
            ValidationTool.Validate(new UserRegisterDtoValidator(), userRegisterDto);

            if (await DbContext.Users.SingleOrDefaultAsync(a => a.PhoneNumber == userRegisterDto.PhoneNumber || a.UserName == userRegisterDto.UserName || a.EmailAddress == userRegisterDto.EmailAddress) is not null)
                return new DataResult(ResultStatus.Error, "Bu kullanıcı mevcut");

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = Mapper.Map<User>(userRegisterDto);
            user.Birthday = DateTime.Parse(userRegisterDto.Birth, new CultureInfo("es-ES"));
            user.UserName = user.UserName.ToLower();
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.IpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            user.CreatedDate = DateTime.Now;
            user.IsActive = true;
            var accessToken = await CreateAccessTokenForUserAsync(user, false);
            await DbContext.Users.AddAsync(user);
            await DbContext.SaveChangesAsync();

            

            UserToken userToken = new UserToken
            {
                UserID = user.ID,
                User = user,
                Token = accessToken.Token,
                TokenExpiration = accessToken.TokenExpiration,
                CreatedDate = DateTime.Now,
                IpAddress = user.IpAddress
            };
            await DbContext.UserTokens.AddAsync(userToken);
            UserAndOperationClaim userOperationClaim = new UserAndOperationClaim
            {
                UserID = user.ID,
                OperationClaimID = 2 //user
            };
            await DbContext.UserAndOperationClaims.AddAsync(userOperationClaim);
            UserProfile userProfile = new UserProfile()
            {
                User = user,
                UserID = user.ID,
                AboutID=0,
            };

            await DbContext.UserProfiles.AddAsync(userProfile);
            await DbContext.SaveChangesAsync();
            return new DataResult(ResultStatus.Success, $"Hoşgeldiniz Sayın {user.FirstName} {user.LastName}.", new UserWithTokenDto
            {
                User = Mapper.Map<UserDto>(user),
                Token = Mapper.Map<UserTokenDto>(userToken),
            });
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
            var user = await DbContext.Companies.SingleOrDefaultAsync(a => a.ID == companyId);
            if (user is null)
                return new DataResult(ResultStatus.Error, "Böyle Bir Şirket Bulunamadı.");
            var claims = await GetCompanyClaimsAsync(user);
            var accessToken = _jwtHelper.CreateTokenForCompany(user, claims, isRefresh);
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
