using AutoMapper;
using Help247.Common.Constants;
using Help247.Common.Pagination;
using Help247.Common.Utility;
using Help247.Data;
using Help247.Data.Entities;
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
            var query = appDbContext.HelperCategories.AsQueryable().Include(x => x.SubServices).Where(x => x.RecordState == Enums.RecordState.Active);
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

        public async Task<HelperCategoryBO> PostCategoryAsync(HelperCategoryBO helperCategoryBO)
        {
            using (var transaction = await appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var query = await appDbContext.HelperCategories.FirstOrDefaultAsync(x => x.Name == helperCategoryBO.Name);
                    if (query != null)
                    {
                        throw new ArgumentException("Record already exists");
                    }
                    var helperCategory = await appDbContext.HelperCategories.AddAsync(mapper.Map<Help247.Data.Entities.HelperCategory>(helperCategoryBO));
                    await appDbContext.SaveChangesAsync();

                    var imageList = new List<Help247.Data.Entities.Image>();
                    var image = new Help247.Data.Entities.Image()
                    {
                        ImageUrl = helperCategoryBO.ImageUrl,
                        ImageType = ImageType.SubServiceImage,
                        SubServiceId = helperCategory.Entity.Id
                    };
                    imageList.Add(image);
                    var icon = new Help247.Data.Entities.Image()
                    {
                        ImageUrl = helperCategoryBO.IconUrl,
                        ImageType = ImageType.SubServicesIcon,
                        SubServiceId = helperCategory.Entity.Id
                    };
                    imageList.Add(icon);
                    await appDbContext.Images.AddRangeAsync(imageList);
                    await appDbContext.SaveChangesAsync();

                    var subServices = new List<SubService>();
                    foreach (var item in helperCategoryBO.SubServices)
                    {
                        var service = new SubService()
                        {
                            Name = item.Name,
                            Description = item.Description,
                            HelperCategoryId = helperCategory.Entity.Id
                        };
                        subServices.Add(service);
                    }
                    await appDbContext.SubServices.AddRangeAsync(subServices);
                    await appDbContext.SaveChangesAsync();

                    transaction.Commit();
                    return helperCategoryBO;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }

        }

        public async Task PostSubServiceAsync(SubServiceBO subServiceBO)
        {
            var query = await appDbContext.SubServices.FirstOrDefaultAsync(x => x.Name == subServiceBO.Name);
            if (query != null)
            {
                throw new ArgumentException("Record already exists with this name");
            }
            await appDbContext.SubServices.AddAsync(mapper.Map<SubService>(subServiceBO));
            await appDbContext.SaveChangesAsync();
        }

        public async Task PutSubServiceAsync(SubServiceBO subServiceBO)
        {
            var query = await appDbContext.SubServices.FirstOrDefaultAsync(x => x.Id == subServiceBO.Id);
            if (query == null)
            {
                throw new ArgumentException("Record not found.");
            }
            appDbContext.SubServices.Update(mapper.Map<SubService>(subServiceBO));
            await appDbContext.SaveChangesAsync();

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

        public async Task DeleteSubServiceAsync(int id)
        {
            var query = await appDbContext.SubServices.FirstOrDefaultAsync(x => x.Id == id);
            if (query == null)
            {
                throw new ArgumentException("Record not found");
            }

            appDbContext.SubServices.Remove(query);
            await appDbContext.SaveChangesAsync();
        }
    }
}
