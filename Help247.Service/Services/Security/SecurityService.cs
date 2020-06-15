using AutoMapper;
using Help247.Common;
using Help247.Common.Constants;
using Help247.Common.Mailer;
using Help247.Common.Utility;
using Help247.Data;
using Help247.Data.Entities;
using Help247.Service.BO.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Help247.Service.Services.Security
{
    public class SecurityService : ISecurityService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment hostingEnvironment;

        public SecurityService(SignInManager<User> signInManager,
                               UserManager<User> userManager, 
                               IConfiguration configuration,
                               AppDbContext appDbContext,
                               IMapper mapper,
                               IHostingEnvironment hostingEnvironment)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
            this.appDbContext = appDbContext;
            this.mapper = mapper;
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task<UserBO> CreateNewUserAsync(UserBO userBO)
        {
            using (var transaction = await appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var checkUser = appDbContext.Users.SingleOrDefault(x => x.Email == userBO.Email && x.UserName == userBO.UserName);
                    if (checkUser != null)
                    {
                        return null;
                    }
                    
                    var storeUser = mapper.Map<User>(userBO);
                    var user = await userManager.CreateAsync(storeUser, userBO.Password);
                    if (!user.Succeeded)
                    {
                        return new UserBO();
                    }
                    userBO.UserId = storeUser.Id;
                    var userType = "Admin";
                    switch (userBO.UserType)
                    {
                        case Enums.UserType.Helper:
                            userType = "Helper";
                            await appDbContext.Helpers.AddAsync(mapper.Map<Help247.Data.Entities.Helper>(userBO));
                            break;
                        case Enums.UserType.Customer:
                            userType = "Customer";
                            await appDbContext.Customers.AddAsync(mapper.Map<Help247.Data.Entities.Customer>(userBO));
                            break;
                        default:
                            storeUser.IsAdmin = true;
                            await userManager.UpdateAsync(storeUser);
                            break;
                    }
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(storeUser);
                    var confirmPasswordLink = string.Concat(GlobalConfig.APIBaseUrl, $"/api/account/confirmemail?token={Base64UrlEncoder.Encode(token)}&email={storeUser.Email}");
                    var messageBuilder = new EmailBuilder(configuration)
                    {
                        To = new[] { storeUser.Email },
                        Subject = "Welcome To Help 24/7",
                        IsBodyHtml = true,
                        Body = $"Hi {storeUser.UserName} , please click on the link below so that we can confirm your email address. <br/><br/>" +
                        $"{confirmPasswordLink} <br/><br/>" +
                        $"Happy Help!!!"

                    };
                    EmailBuilder.SendEmail(messageBuilder);

                    await userManager.AddToRoleAsync(storeUser, userType);

                    var image = new Help247.Data.Entities.Image()
                    {
                        ImageType = ImageType.ProfilePicture,
                        ImageUrl = userBO.ProfilePicUrl,
                        Email = userBO.Email 
                    };
                    await appDbContext.Images.AddAsync(image);
                    await appDbContext.SaveChangesAsync();

                    transaction.Commit();     
                     return userBO;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task ConfirmEmailAsync(ConfirmEmailBO confirmEmailBO)
        {
            var user = await userManager.FindByEmailAsync(confirmEmailBO.Email);
            if (user != null)
            {

                var result = await userManager.ConfirmEmailAsync(user, Base64UrlEncoder.Decode(confirmEmailBO.Token));
                if (!result.Succeeded)
                {
                    var error = result.Errors.FirstOrDefault();
                    throw new ArgumentException(error.Description);
                }
            }
        }

        public async Task<LoginBO> LoginAsync(LoginBO loginBO)
        {
            try
            {
                var user = await userManager.FindByNameAsync(loginBO.UserName);
                if (user != null && user.RecordState == Enums.RecordState.Active)
                {
                    var result = await signInManager.CheckPasswordSignInAsync(user, loginBO.Password, false);
                    if (result.IsNotAllowed)
                    {
                        throw new UnauthorizedAccessException("Your email has not been confirmed, please confirm your email address");
                    }
                    if (result.Succeeded)
                    {
                        var roles = await userManager.GetRolesAsync(user);
                        int userId = 0;
                        if (roles[0] == Enums.UserType.Helper.ToString())
                        {
                            userId = appDbContext.Helpers.First(x => x.UserId == user.Id).Id;
                        }
                        else if (roles[0] == Enums.UserType.Customer.ToString())
                        {
                            userId = appDbContext.Customers.First(x => x.UserId == user.Id).Id;
                        }

                        var _options = new IdentityOptions();
                        //Create the token
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                            new Claim("LoggedInUserId", userId.ToString()),
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);
                        // Adding roles code
                        // Roles property is string collection but you can modify Select code if it it's not
                        claimsIdentity.AddClaims(roles.Select(role => new Claim(ClaimTypes.Role, role)));
                        claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        //claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, userId.ToString()));
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            configuration["Tokens:Issuer"],
                            configuration["Tokens:Audience"],
                            claimsPrincipal.Identities.First().Claims,
                            expires: DateTime.UtcNow.AddDays(1),
                            signingCredentials: creds
                            );

                        var results = new LoginBO
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            TokenExpiration = token.ValidTo,
                            IsAdmin = user.IsAdmin
                        };

                        return results;
                    }
                }
                return new LoginBO();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task ForgotPasswordAsync(ForgotPasswordBO forgotPasswordBO)
        {
            var user = await userManager.FindByEmailAsync(forgotPasswordBO.Email);
            if (user != null)
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var passwordReseLink = string.Concat(GlobalConfig.APIBaseUrl, $"/api/account/resetpassword?token={Base64UrlEncoder.Encode(token)}&email={user.Email}");

                var messageBuilder = new EmailBuilder(configuration)
                {
                    To = new[] { user.Email },
                    Subject = "Reset Password",
                    IsBodyHtml = true,
                    Body = $"Hi {user.UserName} , please click on the link below reset your password. <br/><br/>" +
                    $"{passwordReseLink} <br/><br/>" +
                    $"Happy Help!!!"
                };
                EmailBuilder.SendEmail(messageBuilder);
            }
            else if (user == null)
            {
                throw new NullReferenceException("This email does not belong to any acccount");
            }
        }

        public async Task ResetPasswordAsync(ResetPassowordBO resetPassowordBO)
        {
            var user = await userManager.FindByEmailAsync(resetPassowordBO.Email);
            if (user != null)
            {
                var result = await userManager.ResetPasswordAsync(user, Base64UrlEncoder.Decode(resetPassowordBO.Token), resetPassowordBO.NewPassword);
                if (!result.Succeeded)
                {
                    var error = result.Errors.FirstOrDefault();
                    throw new ArgumentException(error.Description);
                }
            }
        }

        public async Task<bool> CheckEmailExistAsync(string email)
        {
            var query = await userManager.FindByEmailAsync(email);
            if (query == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> CheckUsernameExistAsync(string username)
        {
            
            var query = await userManager.FindByNameAsync(username.ToLower());
            if (query == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
