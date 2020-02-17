using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.Exceptions
{
    public class RegisterFailedException : Exception
    {
        public RegisterFailedException() : base("User Registration Failed.")
        {

        }
    }
}
