using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.ViewModels.HelperCategory
{
    public class HelperCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LongDescription { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string IconUrl { get; set; }
        public string ImageUrl { get; set; }
        public Dictionary<string, string> ServicesProvided { get; set; }
    }
}
