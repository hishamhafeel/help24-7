using AutoMapper;
using Help247.Common.Pagination;
using Help247.Common.Utility;
using Help247.Data;
using Help247.Data.Entities;
using Help247.Service.BO.Helper;
using Help247.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help247.Service.Services.Helper
{
    public class HelperService : IHelperService
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public HelperService(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public async Task<PaginationModel<HelperBO>> GetAllAsync(PaginationBase paginationBase)
        {
            try
            {
                var query = appDbContext.Helpers.AsQueryable().Include(x => x.HelperCategory).Where(x => x.RecordState == Enums.RecordState.Active);
                if (paginationBase.SearchQuery != null && paginationBase.SearchQuery.Length > 0)
                {
                    query = query.Where(x => EF.Functions.Like(x.PhoneNo, paginationBase.SearchQuery + "%") ||
                                             EF.Functions.Like(x.FirstName.ToLower(), paginationBase.SearchQuery + "%") ||
                                              EF.Functions.Like(x.LastName.ToLower(), paginationBase.SearchQuery + "%") ||
                                             EF.Functions.Like(x.Id.ToString(), paginationBase.SearchQuery + "%") ||
                                             EF.Functions.Like(x.Email.ToLower(), paginationBase.SearchQuery + "%"));
                }
                var totalNumberOfRecord = await query.AsNoTracking().CountAsync();

                query = query.OrderByDescending(x => x.Id).Skip(paginationBase.Skip).Take(paginationBase.Take);
                var result = await query.AsNoTracking().ToListAsync();
                var resultSet = new PaginationModel<HelperBO>()
                {
                    TotalRecords = totalNumberOfRecord,
                    Details = mapper.Map<List<HelperBO>>(result)
                };
                return resultSet;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<HelperBO> GetByIdAsync(int id)
        {
            try
            {
                var query = await appDbContext.Helpers.FirstOrDefaultAsync(x => x.Id == id);
                if (query == null)
                {
                    throw new HelperNotFoundException();
                }
                return mapper.Map<HelperBO>(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<HelperBO> PutAsync(HelperBO helperBO)
        {
            using (var transaction = await appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var query = await appDbContext.Helpers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == helperBO.Id);
                    var imageQuery = await appDbContext.Images.AsNoTracking().FirstOrDefaultAsync(x => x.ImageUrl == helperBO.ProfilePic);
                    if (query == null)
                    {
                        throw new HelperNotFoundException();
                    }
                    else if(imageQuery == null)
                    {
                        var existingImage = await appDbContext.Images.AsNoTracking().FirstAsync(x => x.UserName == helperBO.Email);
                        var newImage = new Help247.Data.Entities.Image()
                        {
                            Id = existingImage.Id,
                            ImageUrl = helperBO.ProfilePic
                        };
                        appDbContext.Images.Update(newImage);
                        await appDbContext.SaveChangesAsync();
                    }

                    appDbContext.Helpers.Update(mapper.Map<Help247.Data.Entities.Helper>(helperBO));
                    await appDbContext.SaveChangesAsync();

                    transaction.Commit();
                    return helperBO;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var transaction = await appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var query = await appDbContext.Helpers.FirstOrDefaultAsync(x => x.Id == id);
                    var userQuery = await appDbContext.Users.FirstOrDefaultAsync(x => x.Email == query.Email);
                    if (query == null || userQuery == null)
                    {
                        throw new HelperNotFoundException();
                    }
                    query.RecordState = Enums.RecordState.Inactive;
                    appDbContext.Helpers.Update(query);
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

        //public async Task<List<HelperCategoryBO>> GetAllHelperCategoryAsync()
        //{
        //    try
        //    {
        //        var query = appDbContext.HelperCategories.ToList().OrderBy(x => x.Id);
        //        if(query == null)
        //        {
        //            throw new HelperCategoryNotFoundException();
        //        }
        //        return mapper.Map<List<HelperCategoryBO>>(query);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
