using Help247.Service.BO.Image;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Help247.Service.Services.Image
{
    public interface IImageService
    {
        Task<ImageBO> GetImageForProfileAsync(string username);
        Task<List<ImageBO>> PostImageForProfileSkillsAsync(ImageUrlBO imageUrls, string username);
    }
}
