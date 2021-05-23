using System;
using System.Collections.Generic;
using SG.Kernel.Types;

namespace Kernel.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
