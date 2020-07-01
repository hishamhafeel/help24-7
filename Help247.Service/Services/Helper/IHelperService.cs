using Help247.Common.Pagination;
using Help247.Service.BO.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Help247.Service.Services.Helper
{
    public interface IHelperService
    {
        Task<PaginationModel<HelperBO>> GetAllAsync(HelperSearchBO helperSearchBO);
        Task<HelperBO> GetByIdAsync(int id);
        Task<HelperBO> PutAsync(HelperBO helperBO, string userId);
        Task DeleteAsync(int id);
        //Task<List<HelperCategoryBO>> GetAllHelperCategoryAsync();
    }
}
