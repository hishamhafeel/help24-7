using Help247.Service.BO.Skill;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Help247.Service.Services.Skill
{
    public interface ISkillService
    {
        Task<SkillListBO> GetByHelperIdAsync(int id);
        Task PostAsync(SkillListBO skillListBO);
    }
}
