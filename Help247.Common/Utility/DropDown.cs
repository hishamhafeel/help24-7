using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Common.Utility
{
    
        public class DropDown<T>
        {
            public T Value { get; set; }
            public string Text { get; set; }
        }

        public abstract class DropDownBo
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
}
