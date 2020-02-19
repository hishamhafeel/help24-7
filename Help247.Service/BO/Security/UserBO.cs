using Help247.Common.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.BO.Security
{
    public class UserBO
    {
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Enums.UserType UserType {get; set;}

    }
}
