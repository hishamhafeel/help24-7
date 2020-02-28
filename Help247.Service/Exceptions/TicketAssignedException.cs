using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.Exceptions
{
    public class TicketAssignedException : Exception
    {
        public TicketAssignedException() : base("Ticket already assigned.")
        {
                
        }
    }
}
