using Help247.Service.BO.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Help247.Service.Services.Security
{
    public interface ISecurityService
    {
        Task<UserBO> CreateNewUserAsync(UserBO userBO);
        Task<LoginBO> LoginAsync(LoginBO loginBO);
    }
}
