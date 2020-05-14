using System.ComponentModel.DataAnnotations;

namespace Help247.Service.BO.Security
{
    public class ResetPassowordBO
    {
        [Required]
        public string Token { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}
