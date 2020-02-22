using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Help247.Common.Pagination;
using Help247.Service.BO.Helper;
using Help247.Service.Services.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Help247.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HelperController : ControllerBase
    {
        private readonly IHelperService helperService;
        private readonly IMapper mapper;

        public HelperController(IHelperService helperService, IMapper mapper)
        {
            this.helperService = helperService;
            this.mapper = mapper;
        }

        // GET: api/HelperList
        [Route("HelperList")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery]PaginationBase paginationBase)
        {
            var result = await helperService.GetAllAsync(paginationBase);
            return Ok(result);
        }

        // GET: api/Helper/5
        [AllowAnonymous]
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await helperService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception)
            {

                return NotFound();
            }
           
        }


        // PUT: api/Helper/5
        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody]HelperBO helperBO)
        {
            try
            {
                var result = await helperService.PutAsync(helperBO);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE: api/ApiWithActions/5
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await helperService.DeleteAsync(id);
                return Ok();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
