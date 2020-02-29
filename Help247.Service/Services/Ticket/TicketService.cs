using AutoMapper;
using Help247.Common.Utility;
using Help247.Data;
using Help247.Data.Entities;
using Help247.Service.BO.Ticket;
using Help247.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Help247.Service.Services.Ticket
{
    public class TicketService : ITicketService
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public TicketService(AppDbContext appDbContext, IMapper mapper, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<TicketBO> AssignTicketAsync(TicketBO ticketBO, string userId)
        {
            using (var transaction = await appDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var query = appDbContext.Tickets.AsNoTracking().FirstOrDefault(x => x.Id == ticketBO.Id);
                    var currentUserType = appDbContext.UserRoles.FirstAsync(x => x.UserId == userId);
                    if (query != null)
                    {
                        throw new TicketAssignedException();
                    }
                    var result = await appDbContext.Tickets.AddAsync(mapper.Map<Help247.Data.Entities.Ticket>(ticketBO));
                    //var createdOn = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                    var createdBy = ClaimsPrincipal.Current.Claims.ToString();
                    var ticketHistory = new TicketHistory()
                    {
                        HelperId = ticketBO.HelperId,
                        CustomerId = ticketBO.CustomerId,
                        CurrentTicketStatus = ticketBO.Status,
                        CreatedById = createdBy,
                        CreatedOn = DateTime.UtcNow
                };
                    //await appDbContext.TicketHistories.AddAsync()
                    if (result == null)
                    {
                        return new TicketBO();
                    }
                    return mapper.Map<TicketBO>(result);
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
