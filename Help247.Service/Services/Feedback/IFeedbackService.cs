using Help247.Common.Pagination;
using Help247.Service.BO.Feedback;
using System.Threading.Tasks;

namespace Help247.Service.Services.Feedback
{
    public interface IFeedbackService
    {
        Task<PaginationModel<FeedbackBO>> GetAllAsync(PaginationBase paginationBase);
        Task<FeedbackBO> GetByIdAsync(int id);
        Task<FeedbackBO> PutAsync(FeedbackBO feedbackBO);
        Task DeleteAsync(int id);
    }
}
