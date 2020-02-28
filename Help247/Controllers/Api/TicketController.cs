using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Help247.Common.Utility;
using Help247.Service.BO.Ticket;
using Help247.Service.Services.Ticket;
using Help247.ViewModels.Ticket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Help247.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService ticketService;
        private readonly IMapper mapper;

        public TicketController(ITicketService ticketService, IMapper mapper)
        {
            this.ticketService = ticketService;
            this.mapper = mapper;
        }

        // GET: api/Ticket
        [HttpGet]
        public async Task<IActionResult> GetTicketStatusAsync(int id)
        {
            return Ok();
        }

        // GET: api/Ticket/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ticket/AssignTicket
        [Route("AssignTicket")]
        [HttpPost]
        [Authorize(Roles = "Customer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignTicket([FromBody] TicketViewModel ticketViewModel)
        {
            try
            {
                if(ticketViewModel.Status != Enums.TicketStatus.HelpRequest) //change to db integration
                {
                    throw new ArgumentException("Ticket status must be HelpRequest.", nameof(Enums.TicketStatus.HelpRequest));
                }
                var result = await ticketService.AssignTicketAsync(mapper.Map<TicketBO>(ticketViewModel));
                if (result == null)
                {
                    return Conflict(result);
                }
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT: api/Ticket/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
