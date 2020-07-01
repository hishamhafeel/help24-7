using AutoMapper;
using Help247.Common.Constants;
using Help247.Common.Pagination;
using Help247.Common.Utility;
using Help247.Data;
using Help247.Data.Entities;
using Help247.Service.BO.Customer;
using Help247.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help247.Service.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public CustomerService(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public async Task<PaginationModel<CustomerBO>> GetAllAsync(PaginationBase paginationBase)
        {
            try
            {
                var query = appDbContext.Customers.AsQueryable().Where(x => x.RecordState == Enums.RecordState.Active);
                if (paginationBase.SearchQuery != null && paginationBase.SearchQuery.Length > 0)
                {
                    query = query.Where(x => EF.Functions.Like(x.Id.ToString(), paginationBase.SearchQuery, "%") ||
                                             EF.Functions.Like(x.Name, paginationBase.SearchQuery, "%") ||
                                             EF.Functions.Like(x.PhoneNo, paginationBase.SearchQuery, "%") ||
                                             EF.Functions.Like(x.Email, paginationBase.SearchQuery, "%"));
                }
                var totalNumberOfRecords = await query.AsNoTracking().CountAsync();
                query.OrderByDescending(x => x.Id).Skip(paginationBase.Skip).Take(paginationBase.Take);
                var result = await query.AsNoTracking().ToListAsync();
                var resultSet = new PaginationModel<CustomerBO>()
                {
                    TotalRecords = totalNumberOfRecords,
                    Details = mapper.Map<List<CustomerBO>>(result)
                };
                return resultSet;
            }
            catch (Exception ex)
            {

                throw  new Exception(ex.Message);
            }

        }

        public async Task<CustomerBO> GetByIdAsync(int id)
        {
            try
            {
                var query = await appDbContext.Customers.Include(x => x.Image).FirstOrDefaultAsync(x => x.Id == id);
                if (query == null)
                {
                    throw new CustomerNotFoundException();
                }
                return mapper.Map<CustomerBO>(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CustomerBO> PutAsync(CustomerBO customerBO, string userId)
        {
            using (var transaction = await appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var query = await appDbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == customerBO.Id);
                    var imageQuery = await appDbContext.Images.FirstOrDefaultAsync(x => x.Email == customerBO.Email && x.ImageType == ImageType.ProfilePicture);

                    if (query == null)
                    {
                        throw new CustomerNotFoundException();
                    }

                    imageQuery.ImageUrl = customerBO.ProfilePicUrl;
                    await appDbContext.SaveChangesAsync();

                    customerBO.ImageId = imageQuery.Id;
                    customerBO.UserId = userId;
                    appDbContext.Customers.Update(mapper.Map<Help247.Data.Entities.Customer>(customerBO));
                    await appDbContext.SaveChangesAsync();
                    transaction.Commit();
                    return customerBO;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
        public async Task DeleteAsync(int id)
        {
            using (var transaction = await appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var query = await appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
                    var userQuery = await appDbContext.Users.FirstOrDefaultAsync(x => x.Email == query.Email);
                    if (query == null || userQuery == null)
                    {
                        throw new CustomerNotFoundException();
                    }
                    query.RecordState = Enums.RecordState.Inactive;
                    appDbContext.Customers.Update(query);
                    userQuery.RecordState = Enums.RecordState.Inactive;
                    appDbContext.Users.Update(userQuery);
                    await appDbContext.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
