using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Help247.Controllers.Api
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseApiController : ControllerBase
    {
        protected int UserId
        {
            get
            {
                try
                {
                    var res = int.TryParse(GetClaims().First(c => c.Type == "sub").Value, out var userid);
                    return userid;
                }
                catch
                {
                    throw new Exception("UserId not founded");
                }
            }
        }

        private List<Claim> GetClaims()
        {
            try
            {
                var tokenString = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
                var token = new JwtSecurityToken(jwtEncodedString: tokenString);
                return token.Claims.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("tenant not founded");
            }
        }

    }
}
