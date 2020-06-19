using Help247.Data.Application;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Help247.Data.Entities
{
    [Table("HelperCategories")]
    public class HelperCategory : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string LongDescription { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        public string IconUrl { get; set; }
        public string ImageUrl { get; set; }
        //public Dictionary<string, string> ServicesProvided { get; set; } = new Dictionary<string, string>();

        #region navigation property
        public List<SubService> SubServices { get; set; }
        #endregion

    }
}
