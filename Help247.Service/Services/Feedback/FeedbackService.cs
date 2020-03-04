using AutoMapper;
using Help247.Common.Pagination;
using Help247.Common.Utility;
using Help247.Data;
using Help247.Service.BO.Feedback;
using Help247.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help247.Service.Services.Feedback
{
    public class FeedbackService : IFeedbackService
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public FeedbackService(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }
        public async Task<PaginationModel<FeedbackBO>> GetAllAsync(PaginationBase paginationBase)
        {
            try
            {
                var query = appDbContext.Feedbacks.AsQueryable().Where(x => x.RecordState == Enums.RecordState.Active);
                if (paginationBase.SearchQuery != null && paginationBase.SearchQuery.Length > 0)
                {
                    query = query.Where(x => EF.Functions.Like(x.Id.ToString(), paginationBase.SearchQuery + "%") ||
                                             EF.Functions.Like(x.Description, paginationBase.SearchQuery + "%"));
                }
                var totalNumberOfRecord = await query.AsNoTracking().CountAsync();

                query = query.OrderByDescending(x => x.Id).Skip(paginationBase.Skip).Take(paginationBase.Take);
                var result = await query.AsNoTracking().ToListAsync();
                var resultSet = new PaginationModel<FeedbackBO>()
                {
                    TotalRecords = totalNumberOfRecord,
                    Details = mapper.Map<List<FeedbackBO>>(result)
                };
                return resultSet;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<FeedbackBO> GetByIdAsync(int id)
        {
            try
            {
                var query = await appDbContext.Feedbacks.FirstOrDefaultAsync(x => x.Id == id);
                if (query == null)
                {
                    throw new FeedbackNotFoundException();
                }
                return mapper.Map<FeedbackBO>(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<FeedbackBO> PutAsync(FeedbackBO feedbackBO)
        {
            try
            {
                var query = await appDbContext.Feedbacks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == feedbackBO.Id);
                if (query == null)
                {
                    throw new FeedbackNotFoundException();
                }
                appDbContext.Feedbacks.Update(mapper.Map<Help247.Data.Entities.Feedback>(feedbackBO));
                await appDbContext.SaveChangesAsync();
                return feedbackBO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var transaction = await appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var query = await appDbContext.Feedbacks.FirstOrDefaultAsync(x => x.Id == id);
                    
                    if (query == null)
                    {
                        throw new FeedbackNotFoundException();
                    }
                    query.RecordState = Enums.RecordState.Inactive;
                    appDbContext.Feedbacks.Update(query);
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
