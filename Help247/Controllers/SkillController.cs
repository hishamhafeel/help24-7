using AutoMapper;
using Help247.Controllers.Api;
using Help247.Service.BO.Skill;
using Help247.Service.Services.Skill;
using Help247.ViewModels.Skill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Help247.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : BaseApiController
    {
        private readonly ISkillService skillService;
        private readonly IMapper mapper;

        public SkillController(ISkillService skillService, IMapper mapper)
        {
            this.skillService = skillService;
            this.mapper = mapper;
        }

        [HttpGet("{helperId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByHelperIdAsync(int helperId)
        {
            try
            {
                if (helperId <= 0)
                {
                    throw new ArgumentException("Invalid Skill Id");
                }
                var result = await skillService.GetByHelperIdAsync(helperId);
                return Ok(mapper.Map<SkillListViewModel>(result));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] SkillListViewModel skillListViewModel)
        {
            try
            {
                if (skillListViewModel.SkillNames.Count <= 0)
                {
                    throw new ArgumentException("Skill names not found");
                }
                else if (skillListViewModel.SkillNames.Count > 5)
                {
                    throw new ArgumentException("Skill names limit exceeded. Only 5 skills are allowed.");
                }
                await skillService.PostAsync(mapper.Map<SkillListBO>(skillListViewModel));
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}