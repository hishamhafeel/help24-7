using Help247.Service.Services.Customer;
using Help247.Service.Services.Feedback;
using Help247.Service.Services.HelpCentre;
using Help247.Service.Services.Helper;
using Help247.Service.Services.HelperCategory;
using Help247.Service.Services.Image;
using Help247.Service.Services.Lookup;
using Help247.Service.Services.Security;
using Help247.Service.Services.Skill;
using Help247.Service.Services.Ticket;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Help247.Utilities.Configurations
{
    public static class IocConfig
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IHelperService, HelperService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IHelperCategoryService, HelperCategoryService>();
            services.AddScoped<IHelpCentreService, HelpCentreService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ILookUpService, LookUpService>();
        }
    }
}
