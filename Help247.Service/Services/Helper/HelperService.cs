using AutoMapper;
using Help247.Common.Constants;
using Help247.Common.Pagination;
using Help247.Common.Utility;
using Help247.Data;
using Help247.Data.Entities;
using Help247.Service.BO.Helper;
using Help247.Service.BO.Image;
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

        public async Task<PaginationModel<HelperBO>> GetAllAsync(HelperSearchBO helperSearchBO)
        {
            try
            {
                var query = appDbContext.Helpers.AsQueryable()
                                                .Include(x => x.HelperCategory)
                                                .Include(x => x.Image)
                                                .Where(x => x.RecordState == Enums.RecordState.Active);

                if (helperSearchBO.HelperCategoryId != 0)
                {
                   query = query.Where(x => x.HelperCategoryId == helperSearchBO.HelperCategoryId);
                }

                query = (!string.IsNullOrEmpty(helperSearchBO.SearchQuery))
                    ? query.Where(x => EF.Functions.Like(x.PhoneNo, helperSearchBO.SearchQuery + "%") ||
                                             EF.Functions.Like(x.FirstName.ToLower(), helperSearchBO.SearchQuery + "%") ||
                                              EF.Functions.Like(x.LastName.ToLower(), helperSearchBO.SearchQuery + "%") ||
                                             EF.Functions.Like(x.Id.ToString(), helperSearchBO.SearchQuery + "%") ||
                                             EF.Functions.Like(x.Email.ToLower(), helperSearchBO.SearchQuery + "%"))
                    : query;

                query = (!string.IsNullOrEmpty(helperSearchBO.Country)) 
                    ? query.Where(x => EF.Functions.Like(x.City, helperSearchBO.City + "%")) 
                    : query;

                query = (!string.IsNullOrEmpty(helperSearchBO.State))
                    ? query.Where(x => EF.Functions.Like(x.City, helperSearchBO.State + "%"))
                    : query;

                query = (!string.IsNullOrEmpty(helperSearchBO.City))
                   ? query.Where(x => EF.Functions.Like(x.City, helperSearchBO.City + "%"))
                   : query;

                var totalNumberOfRecord = await query.AsNoTracking().CountAsync();

                query = query.OrderByDescending(x => x.Id).Skip(helperSearchBO.Skip).Take(helperSearchBO.Take);
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
                var query = await appDbContext.Helpers
                                               .Include(x=>x.HelperCategory)
                                               .Include(x=>x.Image)
                                               .FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task<HelperBO> PutAsync(HelperBO helperBO, string userId)
        {
            using (var transaction = await appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var query = await appDbContext.Helpers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == helperBO.Id);
                    var imageQuery = await appDbContext.Images.FirstOrDefaultAsync(x => x.Email == helperBO.Email && x.ImageType == ImageType.ProfilePicture);

                    if (query == null)
                    {
                        throw new HelperNotFoundException();
                    }

                    imageQuery.ImageUrl = helperBO.ProfilePicUrl;
                    await appDbContext.SaveChangesAsync();

                    helperBO.ImageId = imageQuery.Id;
                    helperBO.UserId = userId;
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
