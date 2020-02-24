using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException() : base("Customer not found. Please try again.")
        {

        }
    }
}
