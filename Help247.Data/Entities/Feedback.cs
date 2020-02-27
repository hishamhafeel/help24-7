using Help247.Data.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Help247.Data.Entities
{
    [Table("Feedbacks")]
    public class Feedback : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }

        #region foreign key
        public int HelperId { get; set; }
        public Helper Helper { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        #endregion
    }
}
