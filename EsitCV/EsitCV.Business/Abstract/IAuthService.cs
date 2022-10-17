using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.AuthDtos;
using EsitCV.Shared.Utilities.Results.Abstract;
using EsitCV.Shared.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.Abstract
{
    public interface IAuthService
    {
        Task<IEnumerable<OperationClaim>> GetUserClaimsAsync(User user);
        Task<IEnumerable<OperationClaim>> GetCompanyClaimsAsync(Company company);
        Task<AccessToken> CreateAccessTokenForUserAsync(User user, bool isRefresh);
        Task<AccessToken> CreateAccessTokenForCompanyAsync(Company company, bool isRefresh);


        Task<IDataResult> CreateAccessTokenByUserIdAsync(int userId, bool isRefresh);
        Task<IDataResult> CreateAccessTokenByCompanyIdAsync(int companyId, bool isRefresh);
        Task<IDataResult> CompanyRegisterAsync(CompanyRegisterDto companyRegisterDto);
        Task<IDataResult> UserRegisterAsync(UserRegisterDto userRegisterDto);
        Task<IDataResult> CompanyLoginWithEmailAsync(CompanyLoginWithEmailDto companyLoginWithEmailDto);
        Task<IDataResult> UserLoginWithEmailAsync(UserLoginWithEmailDto userLoginWithEmailDto);
        //Task<IDataResult> UserForgotPasswordWithEmail();
        //Task<IDataResult> CompanyForgotPasswordWithEmail();
    }
}
