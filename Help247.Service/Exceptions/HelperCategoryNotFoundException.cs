using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.Exceptions
{
    public class HelperCategoryNotFoundException : Exception
    {
        public HelperCategoryNotFoundException() : base("Helper Catergories not found.")
        {

        }
    }
}
