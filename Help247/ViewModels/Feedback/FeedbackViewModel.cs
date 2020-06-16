using Help247.ViewModels.Customer;
using Help247.ViewModels.Helper;
using Help247.ViewModels.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.ViewModels.Feedback
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }
        public DateTime? EditedOn { get; set; }
        public string EditedById { get; set; }
        public int HelperId { get; set; }
        public HelperViewModel Helper { get; set; }
        public int CustomerId { get; set; }
        public CustomerViewModel Customer { get; set; }
        public int TicketId { get; set; }
        public TicketViewModel Ticket { get; set; }
    }
}
