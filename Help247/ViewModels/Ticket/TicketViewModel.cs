using Help247.Common.Utility;
using Help247.ViewModels.Customer;
using Help247.ViewModels.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.ViewModels.Ticket
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public DateTime HelpDateFrom { get; set; }
        public DateTime HelpDateTo { get; set; }
        public string HelpTime { get; set; }
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo1 { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string ContactNo2 { get; set; }
        public string OtherRequirements { get; set; }

        [Required]
        public int TicketStatusId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }
        public bool HasFeedback { get; set; }


        public int CustomerId { get; set; }

        public CustomerViewModel Customer { get; set; }
        public int HelperId { get; set; }

        public HelperViewModel Helper { get; set; }
    }
}
