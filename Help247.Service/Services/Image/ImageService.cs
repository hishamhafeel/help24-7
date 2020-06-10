using AutoMapper;
using Help247.Common.Constants;
using Help247.Data;
using Help247.Service.BO.Image;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.Service.Services.Image
{
    public class ImageService: IImageService
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public ImageService(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public async Task<ImageBO> GetImageForProfileAsync(string username)
        {
            var query = await appDbContext.Images.Where(x => x.ImageType == ImageType.ProfilePicture).FirstOrDefaultAsync(x => x.UserName == username);
            if (query == null)
            {
                throw new ArgumentException("Username not found");
            }

            return mapper.Map<ImageBO>(query);
        }

        public async Task<List<ImageBO>> PostImageForProfileSkillsAsync(ImageUrlBO imageUrls, string username)
        {
            if (imageUrls.ImageUrls.Count > 5)
            {
                throw new ArgumentException("Number of Image Url's exceeded. Limit is 5.");
            }
            var images = new List<Help247.Data.Entities.Image>();

            foreach (var item in imageUrls.ImageUrls)
            {
                var image = new Help247.Data.Entities.Image()
                {
                    ImageType = ImageType.ProfileSkillsPicture,
                    ImageUrl = item,
                    UserName = username

                };
                images.Add(image);
            }

            await appDbContext.AddRangeAsync(images);
            await appDbContext.SaveChangesAsync();
            return mapper.Map<List<ImageBO>>(images);
        }
    }
}
