﻿using EsitCV.Business.AbstractUtilities;
using EsitCV.Entities.Concrete;
using EsitCV.Shared.Extensions;
using EsitCV.Shared.Utilities.Security.Encryption;
using EsitCV.Shared.Utilities.Security.Jwt;
using EsitCV.Shared.Utilities.Security.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.Utilities
{
    public class JwtHelper : IJwtHelper
    {
        IConfiguration Configuration { get; }
        TokenOptions _tokenOptions;
        DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateTokenForUser(User user, IEnumerable<OperationClaim> operationClaims, bool isRefreshToken)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration + 300);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(user, signingCredentials, operationClaims, isRefreshToken);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken()
            {
                Token = token,
                TokenExpiration = _accessTokenExpiration,
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(User user, SigningCredentials signingCredentials, IEnumerable<OperationClaim> operationClaims, bool refreshToken)
        {
            var jwt = new JwtSecurityToken
            (
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                expires: refreshToken == false ? _accessTokenExpiration : DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration + 100),
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }
        public IEnumerable<Claim> SetClaims(User user, IEnumerable<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.ID.ToString());
            claims.AddEmail(user.EmailAddress);
            claims.AddName(user.UserName);
            claims.AddPhone(user.PhoneNumber);
            claims.AddIpAddress(user.IpAddress!);
            claims.AddIsDeletedStatus(user.IsDeleted);
            claims.AddRoles(operationClaims.Select(a => a.Name).ToArray());
            return claims;
        }
    }
}
