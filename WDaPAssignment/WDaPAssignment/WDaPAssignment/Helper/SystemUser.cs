using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;

namespace WDaPAssignment.Helper
{   
    public static class IdentityExtensions
    {

        public static string UserName(this ClaimsPrincipal identity)
        {
            Claim claim = identity?.FindFirst(ClaimTypes.Name);

            return claim?.Value ?? string.Empty;
        }
        public static string Role(this ClaimsPrincipal identity)
        {
            Claim claim = identity?.FindFirst(ClaimTypes.Role);
            return claim?.Value ?? string.Empty;

        }
       

    }
}
