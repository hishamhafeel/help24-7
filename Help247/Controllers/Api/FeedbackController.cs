using AutoMapper;
using Help247.Common.Pagination;
using Help247.Service.BO.Feedback;
using Help247.Service.Services.Feedback;
using Help247.ViewModels.Feedback;
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
        public async Task<IActionResult> GetAllAsync([FromQuery]PaginationBase paginationBase)
        {
            var result = await feedbackService.GetAllAsync(paginationBase);
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

        // PUT: api/Feedback/5
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody]FeedbackViewModel feedbackViewModel)
        {
            try
            {
                var result = await feedbackService.PutAsync(mapper.Map<FeedbackBO>(feedbackViewModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // DELETE: api/Feedback/5
        [HttpDelete("{id}")]
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
