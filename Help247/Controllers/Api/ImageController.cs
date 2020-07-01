using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Help247.Common.Utility;
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
        public async Task<IActionResult> GetImageForProfileAsync([FromQuery] string email)
        {
            try
            {
                if (!RegexUtilities.IsValidEmail(email))
                {
                    throw new ArgumentException("Invalid Email");
                }
                var result = await imageService.GetImageForProfileAsync(email);
                return Ok(mapper.Map<ImageViewModel>(result));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("helpercategory")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetImageForHelperCategoryAsync([FromQuery] int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Invalid Id");
                }
                var result = await imageService.GetImageForHelperCategoryAsync(id);
                return Ok(mapper.Map<List<ImageViewModel>>(result));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("skills")]
        [HttpPost]
        public async Task<IActionResult> PostImageForProfileSkillsAsync([FromBody] ImageUrlViewModel imageUrls)
        {
            try
            {
                if (imageUrls.ImageUrls.Count > 5)
                {
                    throw new ArgumentException("Number of Image Url's exceeded. Limit is 5.");
                }
                var userId = User.GetClaim();
                var result = await imageService.PostImageForProfileSkillsAsync(mapper.Map<ImageUrlBO>(imageUrls), userId);
                return Ok(mapper.Map<List<ImageViewModel>>(result));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("skills")]
        [HttpGet]
        public async Task<IActionResult> GetImageForProfileSkillsAsync(int helperId)
        {
            try
            {
                var result = await imageService.GetImageForProfileSkillsAsync(helperId);
                return Ok(mapper.Map<List<ImageViewModel>>(result));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("helpercategory")]
        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> PostImageForHelperCategoryAsync([FromBody] ImageHelperCategoryViewModel imageModel)
        {
            try
            {
                if (string.IsNullOrEmpty(imageModel.IconUrl) && string.IsNullOrEmpty(imageModel.ImageUrl))
                {
                    throw new ArgumentException("Image or Icon Url not found.");
                }
                var result = await imageService.PostImageForHelperCategoryAsync(mapper.Map<ImageHelperCatergoryBO>(imageModel));
                return Ok(mapper.Map<List<ImageViewModel>>(result));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}