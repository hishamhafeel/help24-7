using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Help247.Common.Utility;
using Help247.Data.Entities;
using Help247.Service.BO.Ticket;
using Help247.Service.Services.Ticket;
using Help247.ViewModels.Ticket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Help247.Controllers.Api
{
    [Route("api/[controller]")]
    public class TicketController : BaseApiController
    {
        private readonly ITicketService ticketService;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public TicketController(ITicketService ticketService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.ticketService = ticketService;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
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
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> AssignTicket([FromBody] TicketViewModel ticketViewModel)
        {
            try
            {
                if (ticketViewModel.TicketStatusId != (int)Enums.TicketStatus.TicketRequest) 
                {
                    throw new ArgumentException("Ticket status must be HelpRequest.");
                }
                var userId = User.GetClaim();
                var result = await ticketService.AssignTicketAsync(mapper.Map<TicketBO>(ticketViewModel), userId);
                if (result == null)
                {
                    return Conflict(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // POST: api/Ticket/ApproveTicket/1
        [Route("ApproveTicket")]
        [HttpPost]
        public async Task<IActionResult> ApproveTicket([FromQuery]int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Ticket ID not found.");
                }
                var userId = User.GetClaim();
                var result = await ticketService.ApproveTicketAsync(id, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // POST: api/Ticket/TerminateTicket/1
        [Route("TerminateTicket")]
        [HttpPost]
        public async Task<IActionResult> TerminateTicket([FromQuery]int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Ticket ID not found.");
                }
                var userId = User.GetClaim();
                var result = await ticketService.TerminateTicketAsync(id, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
