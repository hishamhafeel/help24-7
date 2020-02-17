using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Data.Application
{
    public interface IAuditableEntity
    {
        DateTime CreatedOn { get; set; }
        int CreatedById { get; set; }
        DateTime? EditedOn { get; set; }
        int? EditedById { get; set; }
    }
}
