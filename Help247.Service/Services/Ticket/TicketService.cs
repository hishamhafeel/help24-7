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
                    var query = await appDbContext.Tickets.AsNoTracking().FirstOrDefaultAsync(x => x.Id == ticketId);
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
                   
                    var ticket = new Help247.Data.Entities.Ticket
                    {
                        Id = query.Id,
                        CreatedById = query.CreatedById,
                        CreatedOn = query.CreatedOn,
                        CustomerId = query.CustomerId,
                        HelperId = query.HelperId,
                        TicketStatusId = 2,
                        EditedById =userId,
                        EditedOn = dateOfEdit,
                        RecordState = query.RecordState,
                        City = query.City,
                        State= query.State,
                        Address= query.Address,
                        ContactNo1 = query.ContactNo1,
                        ContactNo2 = query.ContactNo2
                    };
                    appDbContext.Tickets.Update(ticket);
                    await appDbContext.SaveChangesAsync();

                    var ticketHistory = new TicketHistory()
                    {
                        HelperId = ticket.HelperId,
                        CustomerId = ticket.CustomerId,
                        TicketId = ticket.Id,
                        CurrentTicketStatusId = ticket.TicketStatusId,
                        CreatedById = ticket.CreatedById,
                        CreatedOn = ticket.CreatedOn,
                        EditedById = ticket.EditedById,
                        EditedOn = ticket.EditedOn
                    };
                    await appDbContext.TicketHistories.AddAsync(ticketHistory);
                    await appDbContext.SaveChangesAsync();

                    transaction.Commit();
                    return mapper.Map<TicketBO>(ticket);
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
                    var query = await appDbContext.Tickets.AsNoTracking().FirstOrDefaultAsync(x => x.Id == ticketId);
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
                    var ticket = new Help247.Data.Entities.Ticket
                    {
                        Id = query.Id,
                        CreatedById = query.CreatedById,
                        CreatedOn = query.CreatedOn,
                        CustomerId = query.CustomerId,
                        HelperId = query.HelperId,
                        TicketStatusId = 3,
                        EditedById = userId,
                        EditedOn = dateOfEdit,
                        RecordState = query.RecordState,
                        City = query.City,
                        State = query.State,
                        Address = query.Address,
                        ContactNo1 = query.ContactNo1,
                        ContactNo2 = query.ContactNo2
                    };
                    appDbContext.Tickets.Update(ticket);
                    await appDbContext.SaveChangesAsync();

                    var ticketHistory = new TicketHistory()
                    {
                        HelperId = ticket.HelperId,
                        CustomerId = ticket.CustomerId,
                        TicketId = ticket.Id,
                        CurrentTicketStatusId = ticket.TicketStatusId,
                        CreatedById = ticket.CreatedById,
                        CreatedOn = ticket.CreatedOn,
                        EditedById = ticket.EditedById,
                        EditedOn = ticket.EditedOn
                    };
                    await appDbContext.TicketHistories.AddAsync(ticketHistory);
                    await appDbContext.SaveChangesAsync();

                    transaction.Commit();
                    return mapper.Map<TicketBO>(ticket);
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
                    var query = appDbContext.Tickets.AsNoTracking().FirstOrDefault(x => x.Id == ticketId);
                    if (query == null)
                    {
                        throw new ArgumentException("Ticket not found in database");
                    }
                    else if (query.TicketStatusId != 1)
                    {
                        throw new ArgumentException("Ticket status is not valid. Ticket must be in HelpRequest status.");
                    }
                    var ticket = new Help247.Data.Entities.Ticket
                    {
                        Id = query.Id,
                        CreatedById = query.CreatedById,
                        CreatedOn = query.CreatedOn,
                        CustomerId = query.CustomerId,
                        HelperId = query.HelperId,
                        TicketStatusId = 4,
                        EditedById = userId,
                        EditedOn = dateOfEdit,
                        RecordState = query.RecordState,
                        City = query.City,
                        State = query.State,
                        Address = query.Address,
                        ContactNo1 = query.ContactNo1,
                        ContactNo2 = query.ContactNo2
                    };
                    appDbContext.Tickets.Update(ticket);
                    await appDbContext.SaveChangesAsync();

                    var ticketHistory = new TicketHistory()
                    {
                        HelperId = ticket.HelperId,
                        CustomerId = ticket.CustomerId,
                        TicketId = ticket.Id,
                        CurrentTicketStatusId = ticket.TicketStatusId,
                        CreatedById = ticket.CreatedById,
                        CreatedOn = ticket.CreatedOn,
                        EditedById = ticket.EditedById,
                        EditedOn = ticket.EditedOn
                    };
                    await appDbContext.TicketHistories.AddAsync(ticketHistory);
                    await appDbContext.SaveChangesAsync();

                    transaction.Commit();
                    return mapper.Map<TicketBO>(ticket);
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

        public async Task<List<TicketBO>> GetTicketsForEmailAsync(string email)
        {
            var query = appDbContext.Tickets
                .Include(x => x.Customer)
                .Include(x => x.Helper)
                .AsQueryable().Where(x => x.Customer.Email == email || x.Helper.Email == email);

            return mapper.Map<List<TicketBO>>(query);
        }

        public async Task<PaginationModel<TicketBO>> GetAllAsync(TicketSearchBO ticketSearchBO)
        {
            try
            {
                var query = appDbContext.Tickets.AsQueryable()
                    .Include(x => x.Customer)
                    .Include(x => x.Helper)
                    .Where(x => x.RecordState == Enums.RecordState.Active);

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
                    ? query.Where(x => EF.Functions.Like(x.City.ToLower(), ticketSearchBO.SearchQuery + "%") ||
                                             EF.Functions.Like(x.Address.ToLower(), ticketSearchBO.SearchQuery + "%") ||
                                              EF.Functions.Like(x.ContactNo1, ticketSearchBO.SearchQuery + "%") ||
                                             EF.Functions.Like(x.ContactNo2, ticketSearchBO.SearchQuery + "%") ||
                                             EF.Functions.Like(x.Id.ToString(), ticketSearchBO.SearchQuery + "%"))
                    : query;

                var totalNumberOfRecords = await query.AsNoTracking().CountAsync();
                query.OrderByDescending(x => x.Id).Skip(ticketSearchBO.Skip).Take(ticketSearchBO.Take);
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
    }
}
