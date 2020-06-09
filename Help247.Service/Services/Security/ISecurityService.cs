using Help247.Service.BO.Security;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Help247.Service.Services.Security
{
    public interface ISecurityService
    {
        Task<UserBO> CreateNewUserAsync(UserBO userBO/*, IFormFileCollection files*/);
        Task<LoginBO> LoginAsync(LoginBO loginBO);
        Task ConfirmEmailAsync(ConfirmEmailBO confirmEmailBO);
        Task Logout();
        Task ForgotPasswordAsync(ForgotPasswordBO forgotPasswordBO);
        Task ResetPasswordAsync(ResetPassowordBO resetPassowordBO);
        Task<bool> CheckEmailExistAsync(string email);
        Task<bool> CheckUsernameExistAsync(string username);
    }
}
