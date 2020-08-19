using System;
using AutoMapper;
using Help247.Service.BO.Lookup;
using Help247.Service.Services.Lookup;
using Help247.ViewModels.Lookup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Help247.Controllers.Api
{
    [Route("api/common")]
    public class LookUpApiController : BaseApiController
    {
        private readonly ILookUpService lookUpService;
        private readonly IMapper mapper;

        public LookUpApiController(ILookUpService lookUpService, IMapper mapper)
        {
            this.lookUpService = lookUpService;
            this.mapper = mapper;
        }

        [HttpPost("subscribe/{email}")]
        [AllowAnonymous]
        public IActionResult SendSubscriptionMail(string email)
        {
            try
            {
                lookUpService.SendSubscriptionMail(email);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        [HttpPost("subsribe/contactus")]
        [AllowAnonymous]
        public IActionResult SendContactUsMail([FromBody]ContactUsViewModel model)
        {
            try
            {
                lookUpService.SendContactUsMail(mapper.Map<ContactUsBO>(model));
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }
    }
}