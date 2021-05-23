using System;
namespace Kernel.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; } //yazar
        public string Issuer { get; set; } //imza
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }

        public TokenOptions()
        {
        }
    }
}
