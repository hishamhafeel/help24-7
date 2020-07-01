using System;
using System.Threading.Tasks;
using AutoMapper;
using Help247.Common.Pagination;
using Help247.Service.BO.HelperCategory;
using Help247.Service.Services.HelperCategory;
using Help247.ViewModels.HelperCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Help247.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperCategoryController : BaseApiController
    {
        private readonly IHelperCategoryService helperCategoryService;
        private readonly IMapper mapper;

        public HelperCategoryController(IHelperCategoryService helperCategoryService, IMapper mapper)
        {
            this.helperCategoryService = helperCategoryService;
            this.mapper = mapper;
        }

        //GET: api/HelperCategory/List
        [Route("list")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationBase paginationBase)
        {
            try
            {
                var result = await helperCategoryService.GetAllAsync(paginationBase);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }

        //GET: api/HelperCategory
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var result = await helperCategoryService.GetByIdAsync(id);
                return Ok(mapper.Map<HelperCategoryViewModel>(result));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        //POST: api/HelperCategory/
        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> PostCategoryAsync([FromBody] HelperCategoryViewModel helperCategoryViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                var result = await helperCategoryService.PostCategoryAsync(mapper.Map<HelperCategoryBO>(helperCategoryViewModel));
                return Ok(mapper.Map<HelperCategoryViewModel>(result));
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }

        //PUT: api/HelperCategory/
        [HttpPut]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> PutCategoryAsync([FromBody] HelperCategoryViewModel helperCategoryViewModel)
        {
            try
            {
                var result = await helperCategoryService.PutCategoryAsync(mapper.Map<HelperCategoryBO>(helperCategoryViewModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // DELETE: api/HelperCategory/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await helperCategoryService.DeleteCategoryAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }


        #region SubServices

        //POST: api/HelperCategory/subservice
        [Route("subservice")]
        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> PostSubServiceAsync([FromBody]SubServiceViewModel subServiceViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                await helperCategoryService.PostSubServiceAsync(mapper.Map<SubServiceBO>(subServiceViewModel));
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        //PUT: api/HelperCategory/subservice
        [Route("subservice")]
        [HttpPut]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> PutSubServiceAsync([FromBody]SubServiceViewModel subServiceViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                await helperCategoryService.PutSubServiceAsync(mapper.Map<SubServiceBO>(subServiceViewModel));
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        //PUT: api/HelperCategory/subservice
        [Route("subservice")]
        [HttpDelete]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> DeleteSubServiceAsync([FromQuery]int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Invalid Sub Service Id");
                }
                await helperCategoryService.DeleteSubServiceAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        #endregion
    }
}