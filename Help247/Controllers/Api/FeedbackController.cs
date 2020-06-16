using AutoMapper;
using Help247.Common.Pagination;
using Help247.Common.Utility;
using Help247.Service.BO.Feedback;
using Help247.Service.Services.Feedback;
using Help247.ViewModels.Feedback;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.Controllers.Api
{
    [Route("api/[controller]")]
    public class FeedbackController : BaseApiController
    {
        private readonly IFeedbackService feedbackService;
        private readonly IMapper mapper;

        public FeedbackController(IFeedbackService feedbackService, IMapper mapper)
        {
            this.feedbackService = feedbackService;
            this.mapper = mapper;
        }

        // GET: api/feedback/list
        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery]FeedbackSearchViewModel feedbackSearchViewModel)
        {
            var result = await feedbackService.GetAllAsync(mapper.Map<FeedbackSearchBO>(feedbackSearchViewModel));
            return Ok(result);
        }

        // GET: api/Feedback/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var result = await feedbackService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        // GET: api/Feedback/helper
        [Route("helperpublic")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetByHelperAsync([FromQuery]int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Invalid helper id");
                }
                var result = await feedbackService.GetByHelperAsync(id);
                return Ok(mapper.Map<List<FeedbackViewModel>>(result));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        //POST: api/Feedback
        [HttpPost]
        [Authorize(Roles = "Customer, SuperAdmin")]
        public async Task<IActionResult> PostAsync([FromBody]FeedbackViewModel feedbackViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                else if (feedbackViewModel.Rating <= 0)
                {
                    throw new ArgumentException("Rating must be greater than 0.");
                }
                var userId = User.GetClaim();
                await feedbackService.PostAsync(mapper.Map<FeedbackBO>(feedbackViewModel), userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // PUT: api/Feedback/5
        [HttpPut]
        [Authorize(Roles = "Customer, SuperAdmin")]
        public async Task<IActionResult> PutAsync([FromBody]FeedbackViewModel feedbackViewModel)
        {
            try
            {
                var userId = User.GetClaim();
                var result = await feedbackService.PutAsync(mapper.Map<FeedbackBO>(feedbackViewModel), userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // DELETE: api/Feedback/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Customer, SuperAdmin, Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await feedbackService.DeleteAsync(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
