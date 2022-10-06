using EsitCV.Entities.Concrete;
using EsitCV.Shared.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.AbstractUtilities
{
    public interface IJwtHelper
    {
        AccessToken CreateToken(User user, IEnumerable<OperationClaim> operationClaims, bool isRefreshToken);

    }
}
