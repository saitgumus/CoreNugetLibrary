using System;
using Microsoft.IdentityModel.Tokens;

namespace Kernel.Utilities.Security.Encryption
{
    public class SigningCredentialHelper
    {
        public static SigningCredentials CreateSigningCredential(SecurityKey key)
        {
            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
