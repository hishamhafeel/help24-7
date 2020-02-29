using System;
using System.Linq;
using System.Security.Claims;

namespace Help247.Common.Utility
{
    public static class Extension
    {

        public static T GetLoggedInUserId<T>(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var loggedInUserId = principal.FindFirst(ClaimTypes.NameIdentifier);

            if (typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(loggedInUserId, typeof(T));
            }
            else if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
            {
                return loggedInUserId != null ? (T)Convert.ChangeType(loggedInUserId, typeof(T)) : (T)Convert.ChangeType(0, typeof(T));
            }
            else
            {
                throw new Exception("Invalid type provided");
            }
        }

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
