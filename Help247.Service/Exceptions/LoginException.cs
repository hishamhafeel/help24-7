using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException() : base("Login was unsuccessfull")
        {

        }
    }
}
