using Help247.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.BO.Ticket
{
    public class TicketSearchBO : PaginationBase
    {
        public int TicketStatusId { get; set; }
        public int HelperId { get; set; }
        public int CustomerId { get; set; }
    }
}
