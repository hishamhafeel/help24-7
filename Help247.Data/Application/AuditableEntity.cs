using Help247.Common.Utility;
using Help247.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Help247.Data.Application
{
    public class AuditableEntity : IAuditableEntity
    {
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public string CreatedById { get; set; }
        public DateTime? EditedOn { get; set; }
        public string EditedById { get; set; }
        public Enums.RecordState RecordState { get; set; } = Enums.RecordState.Active;


        protected AuditableEntity()
        {

        }

        protected AuditableEntity(User user)
        {
                CreatedOn = DateTime.UtcNow;
                EditedOn = DateTime.UtcNow;
                RecordState = Enums.RecordState.Active;
            
        }
    }
}
