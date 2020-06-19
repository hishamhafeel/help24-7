using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.ViewModels.HelperCategory
{
    public class SubServiceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HelperCategoryId { get; set; }
        //public HelperCategoryViewModel HelperCategory { get; set; }
    }
}
