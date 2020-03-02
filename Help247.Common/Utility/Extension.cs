using System;
using System.Linq;
using System.Security.Claims;

namespace Help247.Common.Utility
{
    public static class Extension
    {

        public static string GetClaim(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier.ToString()).FirstOrDefault();

            if (claim == null)
            {
                throw new Exception(message: "claim not found");
            }

            return claim.Value;
        }
    }
}
