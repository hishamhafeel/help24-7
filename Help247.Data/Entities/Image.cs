using Help247.Common.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Help247.Data.Entities
{
    [Table("Images")]
    public class Image
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string UserName { get; set; }
        public string ImageType { get; set; }
        public int SubServiceId { get; set; }

    }
}
