using Help247.Common.Utility;
using Help247.Data.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Help247.Data.Entities
{
    [Table("Helpers")]
    public class Helper : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Phone]
        public string PhoneNo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string City { get; set; }

        public List<Feedback> Feedbacks { get; set; }
        public List<Ticket> Tickets { get; set; }

        #region foreign key
        public int HelperCategoryId { get; set; }
        public HelperCategory HelperCategory { get; set; }
        #endregion

    }
}
