using Help247.Service.BO.Ticket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Help247.Service.Services.Ticket
{
    public interface ITicketService
    {
        Task<TicketBO> AssignTicketAsync(TicketBO ticketBO);
    }
}
