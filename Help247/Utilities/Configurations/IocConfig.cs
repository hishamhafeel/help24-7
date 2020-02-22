using Help247.Service.Services.Helper;
using Help247.Service.Services.Security;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help247.Utilities.Configurations
{
    public static class IocConfig
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IHelperService, HelperService>();
        }
    }
}
