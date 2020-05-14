using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.BO.HelpCentre
{
    public class HelpCentreBO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Topics { get; set; } 
    }
}
