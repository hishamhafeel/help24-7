using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Help247.Common.Pagination;
using Help247.Common.Utility;
using Help247.Service.BO.Helper;
using Help247.Service.Services.Helper;
using Help247.ViewModels.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Help247.Controllers.Api
{
    [Route("api/[controller]")]
    public class HelperController : BaseApiController
    {
        private readonly IHelperService helperService;
        private readonly IMapper mapper;

        public HelperController(IHelperService helperService, IMapper mapper)
        {
            this.helperService = helperService;
            this.mapper = mapper;
        }

        // GET: api/helper/list
        [Route("list")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery]HelperSearchViewModel helperSearch)
        {
            var result = await helperService.GetAllAsync(mapper.Map<HelperSearchBO>(helperSearch));
            return Ok(result);
        }

        // GET: api/helper/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var result = await helperService.GetByIdAsync(id);
                return Ok(mapper.Map<HelperViewModel>(result));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
           
        }

        // PUT: api/helper/5
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody]HelperViewModel helperViewModel)
        {
            try
            {
                var userId = User.GetClaim();
                var result = await helperService.PutAsync(mapper.Map<HelperBO>(helperViewModel), userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // DELETE: api/helper/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await helperService.DeleteAsync(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        //[Route("HelperCategoryList")]
        //[HttpGet]
        //public async Task<IActionResult> GetHelperCategoryListAsync()
        //{
        //    try
        //    {
        //        var result = await helperService.GetAllHelperCategoryAsync();
        //        return Ok(mapper.Map<List<HelperCategoryViewModel>>(result));
        //    }
        //    catch (Exception ex)
        //    {
        //        return HandleException(ex);
        //    }
        //}

    }
}
