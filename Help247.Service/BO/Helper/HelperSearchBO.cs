using Help247.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.BO.Helper
{
    public class HelperSearchBO : PaginationBase
    {
        public int HelperCategoryId { get; set; }
        public string Country { get; set; } 
        public string State { get; set; } 
        public string City { get; set; }
    }
}
