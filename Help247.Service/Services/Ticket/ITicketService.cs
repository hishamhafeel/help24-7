using Help247.Common.Pagination;
using Help247.Service.BO.Ticket;
using System.Collections.Generic;
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
        Task<List<TicketBO>> GetTicketsForEmailAsync(string email);
        Task<PaginationModel<TicketBO>> GetAllAsync(TicketSearchBO ticketSearchBO);
        Task<TicketCountBO> GetCountAllAsync(int helperId);
    }
}
