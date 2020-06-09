using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.ViewModels.Image
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string UserName { get; set; }
        public string ImageType { get; set; }
        public int SubServiceId { get; set; }
    }
}
