using Help247.Common.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.ViewModels.Helper
{
    public class HelperViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }
        [DataType(DataType.EmailAddress)]
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
    }
}
