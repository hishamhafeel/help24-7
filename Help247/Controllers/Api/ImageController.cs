using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Help247.Service.BO.Image;
using Help247.Service.Services.Image;
using Help247.ViewModels.Image;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Help247.Controllers.Api
{
    [Route("api/[controller]")]
    public class ImageController : BaseApiController
    {
        private readonly IMapper mapper;
        private readonly IImageService imageService;

        public ImageController(IMapper mapper, IImageService imageService)
        {
            this.mapper = mapper;
            this.imageService = imageService;
        }

        [Route("profile")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetImageForProfileAsync([FromQuery] string username)
        {
            try
            {
                var result = await imageService.GetImageForProfileAsync(username);
                return Ok(mapper.Map<ImageViewModel>(result));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("skills")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostImageForProfileSkillsAsync([FromBody] ImageUrlViewModel imageUrls, string username)
        {
            try
            {
               var result = await imageService.PostImageForProfileSkillsAsync(mapper.Map<ImageUrlBO>(imageUrls), username);
                return Ok(mapper.Map<List<ImageViewModel>>(result));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}