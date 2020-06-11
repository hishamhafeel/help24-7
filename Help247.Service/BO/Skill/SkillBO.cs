using System.Collections.Generic;

namespace Help247.Service.BO.Skill
{
    public class SkillBO
    {
        public int Id { get; set; }
        public List<string> SkillNames { get; set; }
        public int HelperId { get; set; }
    }
}
