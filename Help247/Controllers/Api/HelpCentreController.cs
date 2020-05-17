using System;
using System.Threading.Tasks;
using AutoMapper;
using Help247.Common.Pagination;
using Help247.Service.BO.HelpCentre;
using Help247.Service.Services.HelpCentre;
using Help247.ViewModels.HelpCentre;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Help247.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpCentreController : BaseApiController
    {
        private readonly IHelpCentreService helpCentreService;
        private readonly IMapper mapper;

        public HelpCentreController(IHelpCentreService helpCentreService, IMapper mapper)
        {
            this.helpCentreService = helpCentreService;
            this.mapper = mapper;
        }

        //GET: api/HelpCentre/List
        [Route("List")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationBase paginationBase)
        {
            try
            {
                var result = await helpCentreService.GetAllAsync(paginationBase);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }

        //PUT: api/HelpCentre/
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutCentreTopicsAsync([FromBody] HelpCentreUpdateViewModel helpCentreViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                var result = await helpCentreService.PutCentreTopicsAsync(mapper.Map<HelpCentreUpdateBo>(helpCentreViewModel));
                return Ok(result);
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }
    }
}