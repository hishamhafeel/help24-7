using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Help247.Common;
using Help247.Common.Constants;
using Help247.Common.Pagination;
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

        [Route("createadmin")]
        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreateAdmin([FromBody]AdminRegisterViewModel registerViewModel)
        {
            try
            {
                var result = await securityService.CreateAdminAsync(mapper.Map<UserBO>(registerViewModel));
                if (result == null)
                {
                    return Conflict(new { message = "Username or Email already in use" });
                }
                else
                {
                    return Created(string.Empty, mapper.Map<RegisterViewModel>(result));
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

        [Route("admin/list")]
        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetAdminList([FromQuery] PaginationBase paginationBase)
        {
            try
            {
                var result = await securityService.GetAdminListAsync(paginationBase);

                return Ok(result);
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

        [Route("checkemail")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> CheckEmailExistAsync([FromQuery] string email)
        {
            try
            {
                if (!RegexUtilities.IsValidEmail(email))
                {
                    throw new ArgumentException("Invalid email address format");
                }

                var result = await securityService.CheckEmailExistAsync(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        [Route("checkusername")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> CheckUsernameExistAsync([FromQuery] string username)
        {
            try
            {
                var result = await securityService.CheckUsernameExistAsync(username);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        [Route("admin")]
        [HttpDelete]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteAdmin([FromQuery]string userId)
        {
            try
            {
                var result = await securityService.DeleteAdminAsync(userId);
                return Ok(mapper.Map<RegisterViewModel>(result));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

    }
}