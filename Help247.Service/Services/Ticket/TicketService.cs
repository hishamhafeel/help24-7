using AutoMapper;
using Help247.Data;
using Help247.Service.BO.Ticket;
using Help247.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<TicketBO> AssignTicketAsync(TicketBO ticketBO)
        {
            try
            {
                var query = appDbContext.Tickets.AsNoTracking().FirstOrDefault(x => x.Id == ticketBO.Id);
                if (query != null)
                {
                    throw new TicketAssignedException();
                }
                var result = await appDbContext.Tickets.AddAsync(mapper.Map<Help247.Data.Entities.Ticket>(ticketBO));
                if (result == null)
                {
                    return new TicketBO();
                }
                return mapper.Map<TicketBO>(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
