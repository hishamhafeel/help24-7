using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.ViewModels.Feedback
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public int HelperId { get; set; }
        public int CustomerId { get; set; }
    }
}
