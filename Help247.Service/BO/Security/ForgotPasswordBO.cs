using System.ComponentModel.DataAnnotations;

namespace Help247.Service.BO.Security
{
    public class ForgotPasswordBO
    {
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
