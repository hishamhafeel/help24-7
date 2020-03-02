using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Help247.Common.Utility;
using Help247.Data.Entities;
using Help247.Service.BO.Security;
using Help247.Service.Exceptions;
using Help247.Service.Services.Security;
using Help247.ViewModels.Account;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Help247.Controllers.Api
{
    [Route("api/[controller]")]
    public class AccountController : BaseApiController
    {
        private readonly ISecurityService securityService;
        private readonly IMapper mapper;

        public AccountController(ISecurityService securityService, IMapper mapper)
        {
            this.securityService = securityService;
            this.mapper = mapper;
        }

        [Route("Register")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel registerViewModel)
        {
            try
            {
                var result = await securityService.CreateNewUserAsync(mapper.Map<UserBO>(registerViewModel));
                if (result == null)
                {
                    return Conflict(new { message = "Username is already in use" });
                }
                else
                {
                    return Created(string.Empty, result);
                }
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("Authenticate")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var modelMapped = mapper.Map<LoginBO>(model);
                    var result = await securityService.LoginAsync(modelMapped);
                    if (result.Token != null)
                    {
                        return Created("", result);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}