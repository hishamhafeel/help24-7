using Help247.Service.BO.Image;
using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.BO.Customer
{
    public class CustomerBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
        public string UserId { get; set; }
        public ImageBO Image { get; set; }
        public int? ImageId { get; set; }
        public string ProfilePicUrl { get; set; }
        public DateTime EditedOn { get; set; }

    }
}
