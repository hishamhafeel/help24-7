using Help247.Common.Utility;
using Help247.Data.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Help247.Data.Entities
{
    [Table("Tickets")]
    public class Ticket : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        #region foreign key
        public int HelperId { get; set; }
        public Helper Helper { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int TicketStatusId { get; set; }
        public TicketStatus TicketStatus { get; set; }
        #endregion

        #region overrides
        [Required]
        public override string CreatedById { get; set; }
        #endregion
    }
}
