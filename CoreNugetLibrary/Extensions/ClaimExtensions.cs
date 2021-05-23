using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace SG.Kernel.Extensions
{
    public static class ClaimExtensions
    {
         public static void AddEmail(this ICollection<Claim> claims,string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameId(this ICollection<Claim> claims, string nameId)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier,nameId));
        }

        public static void AddRole(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(e => claims.Add(new Claim(ClaimTypes.Role, e)));
        }
    }
}
