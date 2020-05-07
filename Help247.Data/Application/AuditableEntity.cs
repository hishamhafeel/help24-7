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
        public virtual DateTime CreatedOn { get; set; }
        public virtual string CreatedById { get; set; }
        public virtual DateTime? EditedOn { get; set; }
        public virtual string EditedById { get; set; }
        public Enums.RecordState RecordState { get; set; }


        protected AuditableEntity()
        {
            CreatedOn = DateTime.UtcNow;
            EditedOn = DateTime.UtcNow;
            RecordState = Enums.RecordState.Active;
        }

    }
}
