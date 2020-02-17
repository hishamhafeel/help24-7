using AutoMapper;
using Help247.Common.Utility;
using Help247.Data;
using Help247.Data.Entities;
using Help247.Service.BO.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
                        break;
                    case Enums.UserType.Customer:
                        userType = "Customer";
                        break;
                    default:
                        break;
                }
                await userManager.AddToRoleAsync(storeUser, userType);
                return userBO;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        //private void CheckRole(UserBO user)
        //{
        //    if (!user.HasRole("Supervisor"))
        //    {
        //        throw new NoSupervisorRoleException("User does not have supervisor role!");
        //    }
        //}
    }
}
