using Help247.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.ViewModels.Ticket
{
    public class TicketSearchViewModel : PaginationBase
    {
        public int TicketStatusId { get; set; }
        public int HelperId { get; set; }
        public int CustomerId { get; set; }
        public string HelperName { get; set; }
        public string CustomerName { get; set; }
    }
}
