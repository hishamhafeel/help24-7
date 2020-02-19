using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Help247.Service.BO.Security
{
    public class LoginBO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Token { get; set; }
        public DateTime? TokenExpiration { get; set; }
        public bool IsAdmin { get; set; }
    }
}
