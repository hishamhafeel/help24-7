using Help247.Common.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.ViewModels.Ticket
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        [Required]
        public int TicketStatusId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedById { get; set; }
        [Required]
        public int HelperId { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}
