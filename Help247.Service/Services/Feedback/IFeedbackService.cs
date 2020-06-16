using Help247.Common.Pagination;
using Help247.Service.BO.Feedback;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Help247.Service.Services.Feedback
{
    public interface IFeedbackService
    {
        Task<PaginationModel<FeedbackBO>> GetAllAsync(FeedbackSearchBO feedbackSearchBO);
        Task<FeedbackBO> GetByIdAsync(int id);
        Task<FeedbackBO> PutAsync(FeedbackBO feedbackBO, string userId);
        Task DeleteAsync(int id);
        Task<List<FeedbackBO>> GetByHelperAsync(int id);
        Task PostAsync(FeedbackBO feedbackBO, string userId);
    }
}
