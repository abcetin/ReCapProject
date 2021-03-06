using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {

        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType) //JWT den gelen claimerlini okumak için 
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();  // (?) soru işareti null olabileceğini söyler
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal) //Direkt rolleri döndürmek için
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
