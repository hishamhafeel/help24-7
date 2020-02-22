using Help247.Common.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.BO.Helper
{
    public class HelperBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public Enums.HelperCategory HelperCategory { get; set; } = Enums.HelperCategory.None;
    }
}
