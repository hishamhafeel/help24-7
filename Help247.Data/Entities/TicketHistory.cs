using Help247.Data.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Help247.Data.Entities
{
    public class TicketHistory : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int HelperId { get; set; }
        public int CustomerId { get; set; }
        public string CurrentTicketStatus { get; set; }
    }
}
