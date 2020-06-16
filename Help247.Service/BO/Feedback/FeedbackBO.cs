using Help247.Service.BO.Customer;
using Help247.Service.BO.Helper;
using Help247.Service.BO.Ticket;
using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.BO.Feedback
{
    public class FeedbackBO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public int HelperId { get; set; }
        public HelperBO Helper { get; set; }
        public int CustomerId { get; set; }
        public CustomerBO Customer { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }
        public DateTime? EditedOn { get; set; }
        public string EditedById { get; set; }
        public int TicketId { get; set; }
        public TicketBO Ticket { get; set; }
    }
}
