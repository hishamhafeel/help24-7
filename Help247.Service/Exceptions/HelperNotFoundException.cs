using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.Exceptions
{
    public class HelperNotFoundException : Exception
    {
        public HelperNotFoundException() : base("Helper not found. Please try with valid Helper ID.")
        {

        }
    }
}
