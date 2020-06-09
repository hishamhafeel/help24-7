using Help247.Service.BO.Ticket;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Help247.Service.Services.Ticket
{
    public interface ITicketService
    {
        Task<TicketBO> AssignTicketAsync(TicketBO ticketBO, string userID);
        Task<TicketBO> ApproveTicketAsync(int ticketId, string userID);
        Task<TicketBO> CompleteTicketAsync(int ticketId, string userID);
        Task<TicketBO> CancelTicketAsync(int ticketId, string userID);
        Task<int> GetTicketStatusAsync(int id);
    }
}
