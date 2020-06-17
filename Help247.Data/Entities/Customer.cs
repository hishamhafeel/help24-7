using Help247.Data.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Help247.Data.Entities
{
    [Table("Customers")]
    public class Customer : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string AddressLine { get; set; }
        public string UserId { get; set; }


        public List<Ticket> Tickets { get; set; }
        public List<Feedback> Feedbacks { get; set; }

        public int? ImageId { get; set; }
        [ForeignKey(nameof(ImageId))]
        public Image Image { get; set; }
    }
}
