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
        public string Title { get; set; }
        [Required]
        public DateTime HelpDateFrom { get; set; }
        public DateTime HelpDateTo { get; set; }
        public string HelpTime { get; set; }

        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo1 { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string ContactNo2 { get; set; }
        public string OtherRequirements { get; set; }
        public bool HasFeedback { get; set; }


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
