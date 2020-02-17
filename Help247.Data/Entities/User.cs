using Help247.Common.Utility;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Help247.Data.Entities
{
    [Table("Users", Schema = "help247")]
    public class User : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string CreatedById { get; set; }
        public DateTime? EditedOn { get; set; } = DateTime.UtcNow;
        public string EditedById { get; set; }
        public Enums.RecordStatus RecordState { get; set; }
    }
}
