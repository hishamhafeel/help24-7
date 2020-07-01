using Help247.Service.BO.Image;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Help247.Service.Services.Image
{
    public interface IImageService
    {
        Task<ImageBO> GetImageForProfileAsync(string email);
        Task<List<ImageBO>> PostImageForProfileSkillsAsync(ImageUrlBO imageUrls, string userId);
        Task<List<ImageBO>> PostImageForHelperCategoryAsync(ImageHelperCatergoryBO imageBO);
        Task<List<ImageBO>> GetImageForHelperCategoryAsync(int id);
        Task<List<ImageBO>> GetImageForProfileSkillsAsync(int helperId);
    }
}
