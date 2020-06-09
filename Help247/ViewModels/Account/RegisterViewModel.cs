using Help247.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.ViewModels.Account
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Enums.UserType UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string AddressLine { get; set; }
        public int Experience { get; set; }
        public string ProfilePicUrl { get; set; }
        public string AboutMe { get; set; }
        public string MyService { get; set; }
        public int HelperCategoryId { get; set; }

        //for customer
        public string Name { get; set; }

    }
}
