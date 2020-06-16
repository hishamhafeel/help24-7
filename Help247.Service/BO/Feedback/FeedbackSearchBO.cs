using Help247.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.BO.Feedback
{
    public class FeedbackSearchBO : PaginationBase
    {
        public int HelperId { get; set; }
        public int CustomerId { get; set; }
        public int TicketId { get; set; }
    }
}
