using Help247.Common.Pagination;
using Help247.Service.BO.HelperCategory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Help247.Service.Services.HelperCategory
{
    public interface IHelperCategoryService
    {
        Task<HelperCategoryBO> PostCategoryAsync(HelperCategoryBO helperCategoryBO);
        Task<PaginationModel<HelperCategoryBO>> GetAllAsync(PaginationBase paginationBase);
        Task<HelperCategoryBO> GetByIdAsync(int id);
        Task<List<HelperCategoryDropDownBO>> GetHelperCategories();
        Task<HelperCategoryBO> PutCategoryAsync(HelperCategoryBO helperCategoryBO);
        Task DeleteCategoryAsync(int id);
        Task PostSubServiceAsync(SubServiceBO subServiceBO);
        Task PutSubServiceAsync(SubServiceBO subServiceBO);
        Task DeleteSubServiceAsync(int id);
    }
}
