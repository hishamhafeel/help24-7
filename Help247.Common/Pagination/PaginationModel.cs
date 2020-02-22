using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Common.Pagination
{
    public class PaginationModel<T> : PaginationBase where T : class
    {
        public int TotalRecords { get; set; }

        public IEnumerable<T> Details { get; set; }
        public dynamic ExtensionData { get; set; }
    }
}
