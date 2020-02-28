using AutoMapper;
using Help247.Common.Utility;
using Help247.Data;
using Help247.Data.Entities;
using Help247.Service.BO.Security;
using Help247.Service.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

        public SecurityService(SignInManager<User> signInManager,
                               UserManager<User> userManager, 
                               IConfiguration configuration,
                               AppDbContext appDbContext,
                               IMapper mapper)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
            this.appDbContext = appDbContext;
            this.mapper = mapper;
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
                   
                    await userManager.AddToRoleAsync(storeUser, userType);
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

        public async Task<LoginBO> LoginAsync(LoginBO loginBO)
        {
            try
            {
                var user = await userManager.FindByNameAsync(loginBO.UserName);
                if (user != null && user.RecordState == Enums.RecordState.Active)
                {
                    var result = await signInManager.CheckPasswordSignInAsync(user, loginBO.Password, false);

                    if (result.Succeeded)
                    {
                        //Create the token
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                            new Claim("IsAdmin", user.IsAdmin.ToString())
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            configuration["Tokens:Issuer"],
                            configuration["Tokens:Audience"],
                            claims,
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

        
    }
}
