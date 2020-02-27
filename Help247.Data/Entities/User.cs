using Help247.Common.Utility;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Help247.Data.Entities
{
    [Table("Users")]
    public class User : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; } 
        public string CreatedById { get; set; }
        public DateTime? EditedOn { get; set; } 
        public string EditedById { get; set; }
        public Enums.RecordState RecordState { get; set; } 
        public bool IsAdmin { get; set; }

        protected User()
        {
            IsAdmin = false;
            RecordState = Enums.RecordState.Active;
            CreatedOn = DateTime.UtcNow;
            EditedOn= DateTime.UtcNow;
        }
    }
}
