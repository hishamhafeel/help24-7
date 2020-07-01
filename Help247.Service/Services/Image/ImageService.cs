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

        public async Task<ImageBO> GetImageForProfileAsync(string email)
        {
            var query = await appDbContext.Images.Where(x => x.ImageType == ImageType.ProfilePicture).FirstOrDefaultAsync(x => x.Email == email);
            if (query == null)
            {
                throw new ArgumentException("Username not found");
            }

            return mapper.Map<ImageBO>(query);
        }

        public async Task<List<ImageBO>> GetImageForHelperCategoryAsync(int id)
        {
            var query = await appDbContext.Images.AsQueryable().Where(x => x.SubServiceId == id).ToListAsync();
            if (query == null)
            {
                throw new ArgumentException("Id not found");
            }
            
            return mapper.Map<List<ImageBO>>(query);
        }

        public async Task<List<ImageBO>> PostImageForProfileSkillsAsync(ImageUrlBO imageUrls, string userId)
        {
            var helper = await appDbContext.Helpers.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);

            var query = await appDbContext.Images.AsQueryable().Where(x => x.HelperId == helper.Id && x.ImageType == ImageType.ProfileSkillsPicture).ToListAsync();

            if (query.Count > 0)
            {
                appDbContext.Images.RemoveRange(query);
            }

            var images = new List<Help247.Data.Entities.Image>();

            foreach (var item in imageUrls.ImageUrls)
            {
                var image = new Help247.Data.Entities.Image()
                {
                    ImageType = ImageType.ProfileSkillsPicture,
                    ImageUrl = item,
                    Email = helper.Email,
                    HelperId = helper.Id

                };
                images.Add(image);
            }

            await appDbContext.AddRangeAsync(images);
            await appDbContext.SaveChangesAsync();
            return mapper.Map<List<ImageBO>>(images);
        }

        public async Task<List<ImageBO>> GetImageForProfileSkillsAsync(int helperId)
        {
            var query = await appDbContext.Images.AsQueryable().Where(x => x.HelperId == helperId && x.ImageType == ImageType.ProfileSkillsPicture).ToListAsync();

            return mapper.Map<List<ImageBO>>(query);
        }

        public async Task<List<ImageBO>> PostImageForHelperCategoryAsync(ImageHelperCatergoryBO imageBO)
        {
            var images = new List<Help247.Data.Entities.Image>();
            images.Add(new Data.Entities.Image()
            {
                ImageUrl = imageBO.IconUrl,
                ImageType = ImageType.SubServicesIcon,
                SubServiceId = imageBO.HelperCategoryId
            });

            images.Add(new Data.Entities.Image()
            {
                ImageUrl = imageBO.ImageUrl,
                ImageType = ImageType.SubServiceImage,
                SubServiceId = imageBO.HelperCategoryId
            });


            await appDbContext.AddRangeAsync(images);
            await appDbContext.SaveChangesAsync();
            return mapper.Map<List<ImageBO>>(images);
        }
    }
}
