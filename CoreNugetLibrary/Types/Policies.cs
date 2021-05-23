using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace SG.Kernel.Types
{
    public class Policies
    {
        public Policies()
        {
        }

        /// <summary>
        /// admin kullanıcısı
        /// </summary>
        public const string Admin = "admin";
        /// <summary>
        /// normal kullanıcı (standart yetki)
        /// </summary>
        public const string User = "user";
        /// <summary>
        /// parola değişikliği için
        /// </summary>
        public const string NewPassword = "newpassword";

        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim(ClaimTypes.Role, Admin).Build();
                //.RequireRole(Admin).Build();
        }

        public static AuthorizationPolicy UserPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(User).Build();
        }

        public static AuthorizationPolicy NewPasswordPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(NewPassword).Build();
        }
    }
}
