using Help247.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.ViewModels.Helper
{
    public class HelperSearchViewModel : PaginationBase
    {
        public int HelperCategoryId { get; set; } = 0;
        public string Country { get; set; } = null;
        public string State { get; set; } = null;
        public string City { get; set; } = null;
    }
}
