using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaimDto> operationClaims);
    }
}
