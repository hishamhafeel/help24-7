using System;
using System.Threading.Tasks;
using AutoMapper;
using Help247.Common.Pagination;
using Help247.Service.BO.Customer;
using Help247.Service.Services.Customer;
using Help247.ViewModels.Customer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Help247.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }

        // GET: api/Customer
        [Route("CustomerList")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationBase paginationBase)
        {
            try
            {
                var result = await customerService.GetAllAsync(paginationBase);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {

            try
            {
                var result = await customerService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        // PUT: api/Customer/5
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody]CustomerViewModel customerViewModel)
        {
            try
            {
                var result = await customerService.PutAsync(mapper.Map<CustomerBO>(customerViewModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await customerService.DeleteAsync(id);
                return Ok();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
