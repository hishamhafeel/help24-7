using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.Exceptions
{
    public class FeedbackNotFoundException : Exception
    {
        public FeedbackNotFoundException() : base("Feedback not found. Please try with valid feedback ID")
        {

        }
    }
}
