using Help247.Common.Pagination;
using Help247.Service.BO.HelperCategory;
using System.Threading.Tasks;

namespace Help247.Service.Services.HelperCategory
{
    public interface IHelperCategoryService
    {
        Task<HelperCategoryBO> PostCategoryAsync(HelperCategoryBO helperCategoryBO);
        Task<PaginationModel<HelperCategoryBO>> GetAllAsync(PaginationBase paginationBase);
        Task<HelperCategoryBO> PutCategoryAsync(HelperCategoryBO helperCategoryBO);
        Task DeleteCategoryAsync(int id);
    }
}
