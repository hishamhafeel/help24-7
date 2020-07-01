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
        public async Task<PaginationModel<FeedbackBO>> GetAllAsync(FeedbackSearchBO feedbackSearchBO)
        {
            try
            {
                var query = appDbContext.Feedbacks.AsQueryable()
                                                    .Include(x => x.Customer)
                                                    .Include(x => x.Helper)
                                                    .Include(x => x.Ticket)
                                                    .Where(x => x.RecordState == Enums.RecordState.Active);

                query = (feedbackSearchBO.TicketId > 0)
                       ? query.Where(x => x.Ticket.Id == feedbackSearchBO.TicketId)
                       : query;

                query = (feedbackSearchBO.HelperId > 0)
                      ? query.Where(x => x.Helper.Id == feedbackSearchBO.HelperId)
                      : query;

                query = (feedbackSearchBO.CustomerId > 0)
                      ? query.Where(x => x.Customer.Id == feedbackSearchBO.CustomerId)
                      : query;

                query = (!string.IsNullOrEmpty(feedbackSearchBO.SearchQuery))
                     ? query.Where(x => EF.Functions.Like(x.Id.ToString(), feedbackSearchBO.SearchQuery + "%") ||
                                        EF.Functions.Like(x.Description.ToLower(), feedbackSearchBO.SearchQuery.ToLower() + "%"))
                     : query;

               
                var totalNumberOfRecord = await query.AsNoTracking().CountAsync();

                query = query.OrderByDescending(x => x.Id).Skip(feedbackSearchBO.Skip).Take(feedbackSearchBO.Take);
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

        public async Task<List<FeedbackBO>> GetByHelperAsync(int id)
        {
            try
            {
                var query = await appDbContext.Feedbacks.AsQueryable()
                    .Include(x => x.Helper)
                    .Include(x => x.Customer)
                    .Include(x => x.Ticket)
                    .Where(x => x.HelperId == id).OrderByDescending(x => x.Id).ToListAsync();
                if (query == null)
                {
                    throw new FeedbackNotFoundException();
                }
                
                return mapper.Map<List<FeedbackBO>>(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task PostAsync(FeedbackBO feedbackBO, string userId)
        {
            using (var transaction = await appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var ticket = await appDbContext.Tickets.FirstAsync(x => x.Id == feedbackBO.TicketId);
                    feedbackBO.CreatedById = userId;
                    feedbackBO.CreatedOn = DateTime.UtcNow;

                    await appDbContext.Feedbacks.AddAsync(mapper.Map<Help247.Data.Entities.Feedback>(feedbackBO));
                    await appDbContext.SaveChangesAsync();

                    ticket.HasFeedback = true;
                    appDbContext.Tickets.Update(ticket);
                    await appDbContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;                
                }
            }
                
        }

        public async Task<FeedbackBO> PutAsync(FeedbackBO feedbackBO, string userId)
        {
            try
            {
                var query = await appDbContext.Feedbacks.FirstOrDefaultAsync(x => x.Id == feedbackBO.Id);
                if (query == null)
                {
                    throw new FeedbackNotFoundException();
                }

                query.EditedById = userId;
                query.EditedOn = DateTime.UtcNow;
                query.Description = feedbackBO.Description;
                query.Rating = feedbackBO.Rating;
                
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
