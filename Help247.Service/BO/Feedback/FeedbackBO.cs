using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.BO.Feedback
{
    public class FeedbackBO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public int HelperId { get; set; }
        public int CustomerId { get; set; }
    }
}
