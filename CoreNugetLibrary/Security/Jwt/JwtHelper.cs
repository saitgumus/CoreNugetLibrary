using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Kernel.Utilities.Security.Encryption;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using SG.Kernel.Extensions;
using SG.Kernel.Types;

namespace Kernel.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration;
        private TokenOptions tokenOptions;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            //    tokenOptions = Configuration.GetSection("TokenOptions").GetChildren() as TokenOptions;
            tokenOptions = new TokenOptions();
            tokenOptions.SecurityKey = configuration["TokenOptions:SecurityKey"];
            tokenOptions.Issuer = configuration["TokenOptions:Issuer"];
            tokenOptions.Audience = configuration["TokenOptions:Audience"];
            tokenOptions.AccessTokenExpiration = Convert.ToInt32(configuration["TokenOptions:AccessTokenExpiration"]);

        }

        /// <summary>
        /// Create token
        /// </summary>
        /// <param name="user">user contract</param>
        /// <param name="operationClaims">operation claims for user</param>
        /// <returns> string: </returns>
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.GetSecurityKey(tokenOptions.SecurityKey);
            var securitySigning = SigningCredentialHelper.CreateSigningCredential(securityKey);

            var jwt = CreateJwtSecurityToken(tokenOptions, user, operationClaims, signingCredentials: securitySigning);
            var jwtSecurityHandler = new JwtSecurityTokenHandler();

            var token = jwtSecurityHandler.WriteToken(jwt);

            AccessToken accessToken = new AccessToken();
            accessToken.Token = token;
            DateTime dateTime = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);
            accessToken.Expiration = dateTime;

            return accessToken;
        }

        /// <summary>
        /// Create JWT token
        /// </summary>
        /// <param name="tokenOptions"></param>
        /// <param name="user"></param>
        /// <param name="operationClaims"></param>
        /// <param name="signingCredentials"></param>
        /// <returns></returns>
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,
            User user,List<OperationClaim> operationClaims, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(issuer:tokenOptions.Issuer,
                audience:tokenOptions.Audience,
                claims:GetClaims(user,operationClaims),
                expires:DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration),
                notBefore:DateTime.Now,
                signingCredentials:signingCredentials);

            return jwt;
        }

        /// <summary>
        /// get claims
        /// </summary>
        /// <param name="user"></param>
        /// <param name="operationClaims"></param>
        /// <returns></returns>
        private IEnumerable<Claim> GetClaims(User user, List<OperationClaim> operationClaims)
        {
            List<Claim> claims = new List<Claim>();
            claims.AddEmail(user.Email);
            claims.AddName(user.UserName);
            claims.AddNameId(user.UserId.ToString());
            claims.AddRole(operationClaims.Select(e => e.Name).ToArray());
            return claims;
        }

    }
}
