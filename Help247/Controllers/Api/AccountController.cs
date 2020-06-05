﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Help247.Common;
using Help247.Common.Constants;
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

        [Route("register")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel registerViewModel)
        {
            try
            {
                //var files = HttpContext.Request.Form.Files;
                var result = await securityService.CreateNewUserAsync(mapper.Map<UserBO>(registerViewModel)/*, files*/);
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

        [Route("confirmemail")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Confirmemail([FromQuery] ConfirmEmailViewModel confirmEmailViewModel)
        {
            try
            {
                await securityService.ConfirmEmailAsync(mapper.Map<ConfirmEmailBO>(confirmEmailViewModel));

                return Redirect(GlobalConfig.PresentationBaseUrl);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }


        [Route("authenticate")]
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

        [Route("forgotpassword")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetPasswordResetEmail([FromBody]ForgotPasswordViewModel forgotPasswordViewModel)
        {
            try
            {
                await securityService.ForgotPasswordAsync(mapper.Map<ForgotPasswordBO>(forgotPasswordViewModel));
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("resetpassword")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody]ResetPasswordViewModel resetPasswordViewModel)
        {
            try
            {
                await securityService.ResetPasswordAsync(mapper.Map<ResetPassowordBO>(resetPasswordViewModel));
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("logout")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await securityService.Logout();
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("checkuser")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> CheckUserExistAsync([FromQuery] string email)
        {
            try
            {
                if (!RegexUtilities.IsValidEmail(email))
                {
                    throw new ArgumentException("Invalid email address format");
                }

                var result = await securityService.CheckUserExistAsync(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

    }
}