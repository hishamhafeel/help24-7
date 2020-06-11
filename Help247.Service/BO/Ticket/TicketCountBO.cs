using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.BO.Ticket
{
    public class TicketCountBO
    {
        public int HelperId { get; set; }
        public int CompletedJobs { get; set; }
        public int AcceptedJobs { get; set; }
        public int PendingJobs { get; set; }
        public int RejectedJobs { get; set; }
    }
}
