using AutoMapper;
using Help247.Common.Pagination;
using Help247.Common.Utility;
using Help247.Data;
using Help247.Service.BO.HelpCentre;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.Service.Services.HelpCentre
{
    public class HelpCentreService : IHelpCentreService
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public HelpCentreService(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public async Task<PaginationModel<HelpCentreBO>> GetAllAsync(PaginationBase paginationBase)
        {
            var query = appDbContext.HelpCentres.AsQueryable().Where(x => x.RecordState == Enums.RecordState.Active);
            var totalNumberOfRecords = await query.AsNoTracking().CountAsync();
            query.OrderByDescending(x => x.Id).Skip(paginationBase.Skip).Take(paginationBase.Take);
            var result = await query.AsNoTracking().ToListAsync();
            var resultSet = new PaginationModel<HelpCentreBO>()
            {
                TotalRecords = totalNumberOfRecords,
                Details = mapper.Map<List<HelpCentreBO>>(result)
            };
            return resultSet;

        }

        public async Task<HelpCentreBO> PutCentreTopicsAsync(HelpCentreBO helpCentreBO)
        {
            var query = await appDbContext.HelpCentres.FirstOrDefaultAsync(x => x.Id == helpCentreBO.Id);
            if (query == null)
            {
                throw new ArgumentException("Help Centre does not exist");
            }
            query.Topics = helpCentreBO.Topics;
            appDbContext.HelpCentres.Update(query);
            await appDbContext.SaveChangesAsync();
            return helpCentreBO;
        }
    }
}
