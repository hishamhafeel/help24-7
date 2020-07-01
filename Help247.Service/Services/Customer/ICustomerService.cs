using Help247.Common.Pagination;
using Help247.Service.BO.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Help247.Service.Services.Customer
{
    public interface ICustomerService
    {
        Task<PaginationModel<CustomerBO>> GetAllAsync(PaginationBase paginationBase);
        Task<CustomerBO> GetByIdAsync(int id);
        Task<CustomerBO> PutAsync(CustomerBO customerBO, string userId);
        Task DeleteAsync(int id);
    }
}
