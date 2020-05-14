using System.ComponentModel.DataAnnotations;

namespace Help247.ViewModels.Account
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string Token { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}
