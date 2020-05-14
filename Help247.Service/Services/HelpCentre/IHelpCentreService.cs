using Help247.Common.Pagination;
using Help247.Service.BO.HelpCentre;
using System.Threading.Tasks;

namespace Help247.Service.Services.HelpCentre
{
    public interface IHelpCentreService
    {
        Task<PaginationModel<HelpCentreBO>> GetAllAsync(PaginationBase paginationBase);
        Task<HelpCentreBO> PutCentreTopicsAsync(HelpCentreBO helpCentreBO);
    }
}
