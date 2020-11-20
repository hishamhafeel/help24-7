using AutoMapper;
using Help247.Common.Pagination;
using Help247.Common.Utility;
using Help247.Data;
using Help247.Data.Entities;
using Help247.Service.BO.Ticket;
using Help247.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.Service.Services.Ticket
{
    public class TicketService : ITicketService
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;
       

        public TicketService(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
            
        }

        public async Task<TicketBO> AssignTicketAsync(TicketBO ticketBO, string userId)
        {
            using (var transaction = await appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var dateOfCreation = DateTime.UtcNow;
                    var query = await appDbContext.Tickets.AsNoTracking().FirstOrDefaultAsync(x => x.Id == ticketBO.Id);
                    if (query != null)
                    {
                        throw new TicketAssignedException();
                    }
                    ticketBO.CreatedById = userId;
                    ticketBO.CreatedOn = dateOfCreation;
                    ticketBO.HasFeedback = false;
                    var result = await appDbContext.Tickets.AddAsync(mapper.Map<Help247.Data.Entities.Ticket>(ticketBO));
                    await appDbContext.SaveChangesAsync();
                    ticketBO.Id = result.Entity.Id;
                    if (result == null)
                    {
                        return new TicketBO();
                    }

                    var ticketHistory = new TicketHistory()
                    {
                        HelperId = ticketBO.HelperId,
                        CustomerId = ticketBO.CustomerId,
                        TicketId = result.Entity.Id,
                        CurrentTicketStatusId = ticketBO.TicketStatusId,
                        CreatedById = userId,
                        CreatedOn = DateTime.UtcNow
                    };
                    await appDbContext.TicketHistories.AddAsync(ticketHistory);
                    await appDbContext.SaveChangesAsync();
                    
                    transaction.Commit();
                    return ticketBO;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<TicketBO> ApproveTicketAsync(int ticketId, string userId)
        {
            using (var transaction = await appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var dateOfEdit = DateTime.UtcNow;
                    var query = await appDbContext.Tickets.FirstOrDefaultAsync(x => x.Id == ticketId);
                    switch (query.TicketStatusId)
                    {
                        case (int)Enums.TicketStatus.None:
                            throw new ArgumentException("Ticket not found in database");
                        case (int)Enums.TicketStatus.HelpRequest:
                            break;
                        case (int)Enums.TicketStatus.HelpProcess:
                            throw new ArgumentException("Help already on progress");
                        case (int)Enums.TicketStatus.HelpComplete:
                            throw new ArgumentException("Help completed successfully");
                        case (int)Enums.TicketStatus.HelpCancel:
                            throw new ArgumentException("Help has been cancelled");
                    }
                   
                    //var ticket = new Help247.Data.Entities.Ticket
                    //{
                    //    Id = query.Id,
                    //    CreatedById = query.CreatedById,
                    //    CreatedOn = query.CreatedOn,
                    //    CustomerId = query.CustomerId,
                    //    HelperId = query.HelperId,
                    //    TicketStatusId = 2,
                    //    EditedById =userId,
                    //    EditedOn = dateOfEdit,
                    //    RecordState = query.RecordState,
                    //    City = query.City,
                    //    State= query.State,
                    //    Address= query.Address,
                    //    ContactNo1 = query.ContactNo1,
                    //    ContactNo2 = query.ContactNo2,
                    //    Title = query.Title,
                    //    Country = query.Country,
                    //    HelpTime = query.HelpTime,
                    //    OtherRequirements = query.OtherRequirements,
                    //    HasFeedback = query.HasFeedback
                    //};

                    //appDbContext.Tickets.Update(ticket);
                    query.TicketStatusId = 2;
                    await appDbContext.SaveChangesAsync();

                    var ticketHistory = new TicketHistory()
                    {
                        HelperId = query.HelperId,
                        CustomerId = query.CustomerId,
                        TicketId = query.Id,
                        CurrentTicketStatusId = query.TicketStatusId,
                        CreatedById = query.CreatedById,
                        CreatedOn = query.CreatedOn,
                        EditedById = query.EditedById,
                        EditedOn = query.EditedOn
                    };
                    await appDbContext.TicketHistories.AddAsync(ticketHistory);
                    await appDbContext.SaveChangesAsync();

                    transaction.Commit();
                    return mapper.Map<TicketBO>(query);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<TicketBO> CompleteTicketAsync(int ticketId, string userId)
        {
            using (var transaction = await appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var dateOfEdit = DateTime.UtcNow;
                    var query = await appDbContext.Tickets.FirstOrDefaultAsync(x => x.Id == ticketId);
                    if (query == null)
                    {
                        throw new ArgumentException("Ticket not found in database");
                    }
                    else if(query.TicketStatusId == 1)
                    {
                        throw new ArgumentException("Ticket has not been approved yet");
                    }
                    else if (query.TicketStatusId == 3)
                    {
                        throw new ArgumentException("Ticket already terminated");

                    }
                    //var ticket = new Help247.Data.Entities.Ticket
                    //{
                    //    Id = query.Id,
                    //    CreatedById = query.CreatedById,
                    //    CreatedOn = query.CreatedOn,
                    //    CustomerId = query.CustomerId,
                    //    HelperId = query.HelperId,
                    //    TicketStatusId = 3,
                    //    EditedById = userId,
                    //    EditedOn = dateOfEdit,
                    //    RecordState = query.RecordState,
                    //    City = query.City,
                    //    State = query.State,
                    //    Address = query.Address,
                    //    ContactNo1 = query.ContactNo1,
                    //    ContactNo2 = query.ContactNo2,
                    //    Title = query.Title,
                    //    Country = query.Country,
                    //    HelpTime = query.HelpTime,
                    //    OtherRequirements = query.OtherRequirements,
                    //    HasFeedback = query.HasFeedback

                    //};
                    //appDbContext.Tickets.Update(ticket);
                    query.TicketStatusId = 3;
                    await appDbContext.SaveChangesAsync();

                    var ticketHistory = new TicketHistory()
                    {
                        HelperId = query.HelperId,
                        CustomerId = query.CustomerId,
                        TicketId = query.Id,
                        CurrentTicketStatusId = query.TicketStatusId,
                        CreatedById = query.CreatedById,
                        CreatedOn = query.CreatedOn,
                        EditedById = query.EditedById,
                        EditedOn = query.EditedOn
                    };
                    await appDbContext.TicketHistories.AddAsync(ticketHistory);
                    await appDbContext.SaveChangesAsync();

                    transaction.Commit();
                    return mapper.Map<TicketBO>(query);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<TicketBO> CancelTicketAsync(int ticketId, string userId)
        {
            using (var transaction = await appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var dateOfEdit = DateTime.UtcNow;
                    var query = appDbContext.Tickets.FirstOrDefault(x => x.Id == ticketId);
                    if (query == null)
                    {
                        throw new ArgumentException("Ticket not found in database");
                    }
                    else if (query.TicketStatusId != 1)
                    {
                        throw new ArgumentException("Ticket status is not valid. Ticket must be in HelpRequest status.");
                    }
                    //var ticket = new Help247.Data.Entities.Ticket
                    //{
                    //    Id = query.Id,
                    //    CreatedById = query.CreatedById,
                    //    CreatedOn = query.CreatedOn,
                    //    CustomerId = query.CustomerId,
                    //    HelperId = query.HelperId,
                    //    TicketStatusId = 4,
                    //    EditedById = userId,
                    //    EditedOn = dateOfEdit,
                    //    RecordState = query.RecordState,
                    //    City = query.City,
                    //    State = query.State,
                    //    Address = query.Address,
                    //    ContactNo1 = query.ContactNo1,
                    //    ContactNo2 = query.ContactNo2,
                    //    Title = query.Title,
                    //    Country = query.Country,
                    //    HelpTime = query.HelpTime,
                    //    OtherRequirements = query.OtherRequirements,
                    //    HasFeedback = query.HasFeedback
                    //};
                    //appDbContext.Tickets.Update(ticket);
                    query.TicketStatusId = 4;
                    await appDbContext.SaveChangesAsync();

                    var ticketHistory = new TicketHistory()
                    {
                        HelperId = query.HelperId,
                        CustomerId = query.CustomerId,
                        TicketId = query.Id,
                        CurrentTicketStatusId = query.TicketStatusId,
                        CreatedById = query.CreatedById,
                        CreatedOn = query.CreatedOn,
                        EditedById = query.EditedById,
                        EditedOn = query.EditedOn
                    };
                    await appDbContext.TicketHistories.AddAsync(ticketHistory);
                    await appDbContext.SaveChangesAsync();

                    transaction.Commit();
                    return mapper.Map<TicketBO>(query);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<int> GetTicketStatusAsync(int id)
        {
            var query = await appDbContext.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (query == null)
            {
                throw new ArgumentException("Record not found");
            }
            return query.TicketStatusId;
        }

        public async Task<TicketBO> GetTicketsById(int id)
        {
            var query = await appDbContext.Tickets
                .Include(x => x.Customer).ThenInclude(a => a.Image)
                .Include(x => x.Helper).ThenInclude(a => a.HelperCategory)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (query == null)
            {
                throw new ArgumentException("Record not found");
            }
            return mapper.Map<TicketBO>(query);
        }

        public async Task<TicketBO> GetLastTicketDetailsAsync()
        {
            var query = await appDbContext.Tickets.OrderByDescending(x => x.Id).FirstAsync();
            return mapper.Map<TicketBO>(query);
        }

        public async Task<PaginationModel<TicketBO>> GetAllAsync(TicketSearchBO ticketSearchBO)
        {
            try
            {
                var query = appDbContext.Tickets.AsQueryable()
                    .Include(x => x.Customer)
                    .Include(x => x.Helper).ThenInclude(a => a.HelperCategory)
                    .Where(x => x.RecordState == Enums.RecordState.Active);

                if (!string.IsNullOrEmpty(ticketSearchBO.CustomerName))
                {
                    query = (!string.IsNullOrEmpty(ticketSearchBO.CustomerName))
                        ? query.Where(x => EF.Functions.Like(x.Customer.Name.ToLower(), ticketSearchBO.CustomerName.ToLower() + "%"))
                        : query;
                }
                else if (!string.IsNullOrEmpty(ticketSearchBO.HelperName))
                {
                    query = (!string.IsNullOrEmpty(ticketSearchBO.HelperName)) 
                        ? query.Where(x => EF.Functions.Like(x.Helper.FirstName.ToLower(), ticketSearchBO.HelperName.ToLower() + "%") ||
                                             EF.Functions.Like(x.Helper.LastName.ToLower(), ticketSearchBO.HelperName.ToLower() + "%"))
                        : query;
                }
                else
                {
                    query = (ticketSearchBO.TicketStatusId > 0)
                        ? query.Where(x => x.TicketStatusId == ticketSearchBO.TicketStatusId)
                        : query;

                    query = (ticketSearchBO.HelperId > 0)
                        ? query.Where(x => x.HelperId == ticketSearchBO.HelperId)
                        : query;

                    query = (ticketSearchBO.CustomerId > 0)
                        ? query.Where(x => x.CustomerId == ticketSearchBO.CustomerId)
                        : query;

                    query = (!string.IsNullOrEmpty(ticketSearchBO.SearchQuery))
                        ? query.Where(x => EF.Functions.Like(x.City.ToLower(), ticketSearchBO.SearchQuery.ToLower() + "%") ||
                                                 EF.Functions.Like(x.Address.ToLower(), ticketSearchBO.SearchQuery.ToLower() + "%") ||
                                                  EF.Functions.Like(x.ContactNo1, ticketSearchBO.SearchQuery + "%") ||
                                                 EF.Functions.Like(x.ContactNo2, ticketSearchBO.SearchQuery + "%") ||
                                                 EF.Functions.Like(x.Id.ToString(), ticketSearchBO.SearchQuery + "%"))
                        : query;
                }
                var totalNumberOfRecords = await query.AsNoTracking().CountAsync();
                query.OrderBy(x => x.Id).Skip(ticketSearchBO.Skip).Take(ticketSearchBO.Take);
                var result = await query.AsNoTracking().ToListAsync();
                var resultSet = new PaginationModel<TicketBO>()
                {
                    TotalRecords = totalNumberOfRecords,
                    Details = mapper.Map<List<TicketBO>>(result)
                };
                return resultSet;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TicketCountBO> GetCountAllAsync(int helperId)
        {
            var query = appDbContext.Tickets.AsQueryable().Where(x => x.HelperId == helperId);

            var pendingJobs = query.Where(x => x.TicketStatusId == (int)Enums.TicketStatus.HelpRequest).Count();
            var acceptedJobs = query.Where(x => x.TicketStatusId == (int)Enums.TicketStatus.HelpProcess).Count();
            var completedJobs = query.Where(x => x.TicketStatusId == (int)Enums.TicketStatus.HelpComplete).Count();
            var rejectedJobs = query.Where(x => x.TicketStatusId == (int)Enums.TicketStatus.HelpCancel).Count();

            return new TicketCountBO()
            {
                HelperId = helperId,
                PendingJobs = pendingJobs,
                AcceptedJobs = acceptedJobs,
                CompletedJobs = completedJobs,
                RejectedJobs = rejectedJobs
            };
        }

        public async Task<TicketBO> PutTicketAsync(TicketBO ticketBO)
        {
            var query = await appDbContext.Tickets.FirstOrDefaultAsync(x => x.Id == ticketBO.Id);
            if (query == null)
            {
                throw new ArgumentException("Ticket not found");
            }
            query.Country = ticketBO.Country;
            query.State = ticketBO.State;
            query.City = ticketBO.City;
            query.Address = ticketBO.Address;
            query.ContactNo1 = ticketBO.ContactNo1;
            query.ContactNo2 = ticketBO.ContactNo2;
            query.HelpDateFrom = ticketBO.HelpDateFrom;
            query.HelpDateTo = ticketBO.HelpDateTo;
            query.HelpTime = ticketBO.HelpTime.ToLower();
            query.OtherRequirements = ticketBO.OtherRequirements;
            query.Title = ticketBO.Title;

            await appDbContext.SaveChangesAsync();
            return ticketBO;
        }
    }
}
