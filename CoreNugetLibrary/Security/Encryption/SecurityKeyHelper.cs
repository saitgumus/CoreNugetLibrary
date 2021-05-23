using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Kernel.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey GetSecurityKey(string key)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }
    }
}
