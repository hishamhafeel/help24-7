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

        public TicketController(ITicketService ticketService, IMapper mapper)
        {
            this.ticketService = ticketService;
            this.mapper = mapper;
        }

        // GET: api/Ticket
        //[HttpGet]
        //public async Task<IActionResult> GetTicketStatusAsync(int id)
        //{
        //    return Ok();
        //}

        // GET: api/Ticket/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/ticker/assign
        [Route("assign")]
        [HttpPost]
        [Authorize(Roles = "Admin, Customer")]
        public async Task<IActionResult> AssignTicketAsync([FromBody] TicketViewModel ticketViewModel)
        {
            try
            {
                if (ticketViewModel.TicketStatusId != (int)Enums.TicketStatus.HelpRequest) 
                {
                    throw new ArgumentException("Ticket status must be HelpRequest.");
                }
                var userId = User.GetClaim();
                var result = await ticketService.AssignTicketAsync(mapper.Map<TicketBO>(ticketViewModel), userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // POST: api/ticker/approve/1
        [Route("approve")]
        [HttpPut]
        [Authorize(Roles = "Admin, Helper")]
        public async Task<IActionResult> ApproveTicketAsync([FromQuery]int id)
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
                return HandleException(ex);
            }
        }

        // POST: api/ticket/complete/1
        [Route("complete")]
        [HttpPut]
        [Authorize(Roles = "Admin, Customer")]
        public async Task<IActionResult> CompleteTicketAsync([FromQuery]int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Ticket ID not found.");
                }
                var userId = User.GetClaim();
                var result = await ticketService.CompleteTicketAsync(id, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // POST: api/ticket/cancel/1
        [Route("cancel")]
        [HttpPut]
        [Authorize(Roles = "Admin, Helper")]
        public async Task<IActionResult> CancelTicketAsync([FromQuery]int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentException("Ticket ID not found.");
                }
                var userId = User.GetClaim();
                var result = await ticketService.CancelTicketAsync(id, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

    }
}
