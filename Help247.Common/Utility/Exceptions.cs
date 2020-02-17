using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Common.Utility
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException() : base("Invalid data")
        {
        }

        public InvalidDataException(string message) : base(message)
        {
        }
    }
}
