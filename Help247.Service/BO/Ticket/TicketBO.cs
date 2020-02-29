using Help247.Common.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.BO.Ticket
{
    public class TicketBO
    {
        public int Id { get; set; }
        public int TicketStatusId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }
        public int HelperId { get; set; }
        public int CustomerId { get; set; }

    }
}
