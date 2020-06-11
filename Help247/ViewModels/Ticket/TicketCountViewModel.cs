using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.ViewModels.Ticket
{
    public class TicketCountViewModel
    {
        public int HelperId { get; set; }
        public int CompletedJobs { get; set; }
        public int AcceptedJobs { get; set; }
        public int PendingJobs { get; set; }
        public int RejectedJobs { get; set; }
    }
}
