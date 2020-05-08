using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.ViewModels.HelpCentre
{
    public class HelpCentreViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Topics { get; set; }
    }
}
