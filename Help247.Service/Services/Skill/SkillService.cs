using AutoMapper;
using Help247.Data;
using Help247.Service.BO.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help247.Service.Services.Skill
{
    public class SkillService : ISkillService
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public SkillService(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public async Task<SkillListBO> GetByHelperIdAsync(int helperId)
        {
            var query = appDbContext.Skills.AsQueryable().Where(x => x.HelperId == helperId);
            if (!query.Any())
            {
                return null;
            }
            var skillListBO = new SkillListBO()
            {
                HelperId = helperId,
                SkillNames = new List<string>()
            };
            foreach (var item in query)
            {
                skillListBO.SkillNames.Add(item.SkillName);
            }
            return skillListBO;
            
        }

        public async Task PostAsync(SkillListBO skillListBO)
        {
            using (var transaction = await appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var query = appDbContext.Skills.AsQueryable().Where(x => x.HelperId == skillListBO.HelperId).ToList();
                    if (query.Count > 0)
                    {
                        appDbContext.Skills.RemoveRange(query);
                    }
                    var skills = new List<Help247.Data.Entities.Skill>();
                    foreach (var item in skillListBO.SkillNames)
                    {
                        var skill = new Help247.Data.Entities.Skill()
                        {
                            SkillName = item,
                            HelperId = skillListBO.HelperId
                        };
                        skills.Add(skill);
                    }

                    await appDbContext.AddRangeAsync(skills);
                    await appDbContext.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
