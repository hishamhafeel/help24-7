using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Help247.Data.Entities
{
    [Table("SubServices")]
    public class SubService
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int HelperCategoryId { get; set; }
        public HelperCategory HelperCategory { get; set; }
    }
}
