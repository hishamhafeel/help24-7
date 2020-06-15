using AutoMapper;
using Help247.Common.Pagination;
using Help247.Common.Utility;
using Help247.Data;
using Help247.Service.BO.HelperCategory;
using Help247.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.Service.Services.HelperCategory
{
    public class HelperCategoryService : IHelperCategoryService
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public HelperCategoryService(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public async Task<PaginationModel<HelperCategoryBO>> GetAllAsync(PaginationBase paginationBase)
        {
            var query = appDbContext.HelperCategories.AsQueryable().Where(x => x.RecordState == Enums.RecordState.Active);
            if (paginationBase.SearchQuery != null && paginationBase.SearchQuery.Length > 0)
            {
                query = query.Where(x => EF.Functions.Like(x.Name.ToLower(), paginationBase.SearchQuery + "%") ||
                                         EF.Functions.Like(x.ShortDescription.ToLower(), paginationBase.SearchQuery + "%") ||
                                          EF.Functions.Like(x.Title.ToLower(), paginationBase.SearchQuery + "%") ||
                                         EF.Functions.Like(x.Id.ToString(), paginationBase.SearchQuery + "%"));
            }

            var totalNumberOfRecords = await query.AsNoTracking().CountAsync();
            query.OrderByDescending(x => x.Id).Skip(paginationBase.Skip).Take(paginationBase.Take);
            var result = await query.AsNoTracking().ToListAsync();
            var resultSet = new PaginationModel<HelperCategoryBO>()
            {
                TotalRecords = totalNumberOfRecords,
                Details = mapper.Map<List<HelperCategoryBO>>(result)
            };
            return resultSet;

        }

        public async Task<HelperCategoryBO> GetByIdAsync(int id)
        {
            try
            {
                var query = await appDbContext.HelperCategories.FirstOrDefaultAsync(x => x.Id == id);
                if (query == null)
                {
                    throw new ArgumentException("Invalid ID. Record not found.");
                }
                return mapper.Map<HelperCategoryBO>(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HelperCategoryBO> PostCategoryAsync(HelperCategoryBO helperCategoryBO)
        {
            var query = await appDbContext.HelperCategories.FirstOrDefaultAsync(x => x.Name == helperCategoryBO.Name);
            if (query != null)
            {
                throw new ArgumentException("Record already exists");
            }
            await appDbContext.HelperCategories.AddAsync(mapper.Map<Help247.Data.Entities.HelperCategory>(helperCategoryBO));
            await appDbContext.SaveChangesAsync();
            return helperCategoryBO;
        }

        public async Task<HelperCategoryBO> PutCategoryAsync(HelperCategoryBO helperCategoryBO)
        {
            var query = await appDbContext.HelperCategories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == helperCategoryBO.Id);
            if (query == null)
            {
                throw new HelperCategoryNotFoundException();
            }
            
            appDbContext.HelperCategories.Update(mapper.Map<Help247.Data.Entities.HelperCategory>(helperCategoryBO));
            await appDbContext.SaveChangesAsync();
            return helperCategoryBO;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var query = await appDbContext.HelperCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (query == null)
            {
                throw new HelperCategoryNotFoundException();
            }
            query.RecordState = Enums.RecordState.Inactive;
            appDbContext.HelperCategories.Update(query);
            await appDbContext.SaveChangesAsync();
        }
    }
}
