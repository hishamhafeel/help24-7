using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.BO.Security
{
    public class AdminUserBO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
