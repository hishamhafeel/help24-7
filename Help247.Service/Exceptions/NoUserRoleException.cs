using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.Exceptions
{
    public class NoUserRoleException : Exception
    {
        public NoUserRoleException() : base("There is no user role registered under this name")
        {

        }
    }
}
