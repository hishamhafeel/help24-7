using Help247.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.ViewModels.Feedback
{
    public class FeedbackSearchViewModel : PaginationBase
    {
        public int HelperId { get; set; }
        public int CustomerId { get; set; }
        public int TicketId { get; set; }
    }
}
