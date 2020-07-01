using Help247.Service.BO.City;
using Help247.Service.BO.Country;
using Help247.Service.BO.State;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Help247.Service.Services.CountryStateCity
{
    public interface ICountryStateCityService
    {
        Task<List<CountryBO>> GetAllCountriesAsync();
        Task<List<StateBO>> GetAllStatesAsync(int countryId);
        Task<List<CityBO>> GetAllCitiesAsync(int stateId);
    }
}
