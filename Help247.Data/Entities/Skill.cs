using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Help247.Data.Entities
{
    [Table("Skills")]
    public class Skill
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SkillName { get; set; }

        #region foreign key
        public int HelperId { get; set; }
        public Helper Helper { get; set; }
        #endregion
    }
}
