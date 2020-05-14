using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Common.Constants
{
    public class FileSaveResult
    {
        public List<string> FileNames { get; set; } = new List<string>();
        public bool FileIsThere { get; set; } = false;
    }
}
