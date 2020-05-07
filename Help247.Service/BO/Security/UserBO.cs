using Help247.Common.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Help247.Service.BO.Security
{
    public class UserBO
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Enums.UserType UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public string PhoneNo { get; set; }
        [Phone]
        public string MobileNo { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        [MaxLength(50)]
        public string AddressLine { get; set; }
        public int Experience { get; set; }
        public string ProfilePicUrl { get; set; }
        public string AboutMe { get; set; }
        public string MyService { get; set; }
        public int HelperCategoryId { get; set; }

    }
}
