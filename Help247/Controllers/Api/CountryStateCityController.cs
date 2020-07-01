using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Help247.Common.Pagination;
using Help247.Service.Services.CountryStateCity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Help247.Controllers.Api
{
    [Route("api/[controller]")]
    public class CountryStateCityController : BaseApiController
    {
        private readonly IMapper mapper;
        private readonly ICountryStateCityService countryStateCity;

        public CountryStateCityController(IMapper mapper, ICountryStateCityService countryStateCity)
        {
            this.mapper = mapper;
            this.countryStateCity = countryStateCity;
        }

        // GET: api/country/list
        [Route("country/list")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await countryStateCity.GetAllCountriesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("state")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllStateAsync([FromQuery]int countryId)
        {
            try
            {
                var result = await countryStateCity.GetAllStatesAsync(countryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // GET: api/country/list
        [Route("city")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCityAsync([FromQuery]int stateId)
        {
            try
            {
                var result = await countryStateCity.GetAllCitiesAsync(stateId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}