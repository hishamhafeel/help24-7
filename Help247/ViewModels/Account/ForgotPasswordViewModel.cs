using System.ComponentModel.DataAnnotations;

namespace Help247.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
