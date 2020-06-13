using Help247.Data.Application;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Help247.Data.Entities
{
    [Table("Helpers")]
    public class Helper : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Phone]
        public string PhoneNo { get; set; }
        [Phone]
        public string MobileNo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string AddressLine { get; set; }
        [Required]
        public int Experience { get; set; }
        [Required]
        public string AboutMe { get; set; }
        [Required]
        public string MyService { get; set; }


        public List<Feedback> Feedbacks { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Skill> Skills { get; set; }

        #region foreign key
        public int HelperCategoryId { get; set; }
        public HelperCategory HelperCategory { get; set; }

        public string UserId { get; set; }
        // public Image Image { get; set; }
        #endregion

    }
}
