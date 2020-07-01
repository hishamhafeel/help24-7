using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Help247.Common.Pagination;
using Help247.Common.Utility;
using Help247.Service.BO.Ticket;
using Help247.Service.Services.Ticket;
using Help247.ViewModels.Ticket;
using Microsoft.AspNetCore.Authorization;
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

        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] TicketSearchViewModel ticketSearchViewModel)
        {
            try
            {
                var ticketsearchBO = mapper.Map<TicketSearchBO>(ticketSearchViewModel);
                var result = await ticketService.GetAllAsync(ticketsearchBO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // GET: api/Ticket/status/1
        [Route("status")]
        [HttpGet]
        public async Task<IActionResult> GetTicketStatusAsync([FromQuery]int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Invalid Ticket Id");
                }
                var result = await ticketService.GetTicketStatusAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }

        [Route("count")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetCountAllAsync([FromQuery]int helperId)
        {
            try
            {
                if (helperId <= 0)
                {
                    throw new ArgumentException("Invalid Helper Id");
                }

                var result = await ticketService.GetCountAllAsync(helperId);
                return Ok(mapper.Map<TicketCountViewModel>(result));
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }

        //GET: api/Ticket/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketsById(int id)
        {
            try
            {
                var result = await ticketService.GetTicketsById(id);
                return Ok(mapper.Map<TicketViewModel>(result));
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }

        // POST: api/ticker/assign
        [Route("assign")]
        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin, Customer")]
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
        [Authorize(Roles = "Admin, Helper, SuperAdmin")]
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
        [Authorize(Roles = "Admin, Customer, SuperAdmin")]
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
        [Authorize(Roles = "Admin, Helper, SuperAdmin")]
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

        // PUT: api/ticket/
        [HttpPut]
        [Authorize(Roles = "Admin, Customer, SuperAdmin")]
        public async Task<IActionResult> PutTicketAsync([FromBody]TicketViewModel ticketViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException();
                }
                var result = await ticketService.PutTicketAsync(mapper.Map<TicketBO>(ticketViewModel));
                return Ok(mapper.Map<TicketViewModel>(result));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

    }
}
