using AutoMapper;
using Help247.Common.Pagination;
using Help247.Data;
using Help247.Service.BO.City;
using Help247.Service.BO.Country;
using Help247.Service.BO.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help247.Service.Services.CountryStateCity
{
    public class CountryStateCityService: ICountryStateCityService
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public CountryStateCityService(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public async Task<List<CountryBO>> GetAllCountriesAsync()
        {
            try
            {
                var query = appDbContext.Countries.AsQueryable();
                if (query == null)
                {
                    throw new ArgumentException("Record not found");
                }

                return mapper.Map<List<CountryBO>>(query.ToList());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<StateBO>> GetAllStatesAsync(int countryId)
        {
            try
            {
                var query = appDbContext.States.AsQueryable().Where(x => x.CountryId == countryId);
                if (query == null)
                {
                    throw new ArgumentException("Record not found");
                }

                return mapper.Map<List<StateBO>>(query.ToList());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<CityBO>> GetAllCitiesAsync(int stateId)
        {
            try
            {
                var query = appDbContext.Cities.AsQueryable().Where(x => x.SateId == stateId);
                if (query == null)
                {
                    throw new ArgumentException("Record not found");
                }

                return mapper.Map<List<CityBO>>(query.ToList());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
