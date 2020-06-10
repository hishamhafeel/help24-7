using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Common.Pagination
{
    public class PaginationBase
    {
        public virtual int Skip { get; set; } = 0;
        public virtual int Take { get; set; } = 10;
        public virtual string SearchQuery { get; set; }
        public virtual bool IsAdmin { get; set; }
        public virtual string OrderBy { get; set; }
    }
}
