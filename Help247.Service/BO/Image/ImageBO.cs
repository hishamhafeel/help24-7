using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.BO.Image
{
    public class ImageBO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string UserName { get; set; }
        public string ImageType { get; set; }
        public int SubServiceId { get; set; }
    }
}
