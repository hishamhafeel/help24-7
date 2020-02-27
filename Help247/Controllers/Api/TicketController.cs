using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // POST: api/Ticket
        [HttpPost]
        [Authorize(Roles = "Customer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] TicketViewModel ticketViewModel)
        {
            try
            {
                return Ok();
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
