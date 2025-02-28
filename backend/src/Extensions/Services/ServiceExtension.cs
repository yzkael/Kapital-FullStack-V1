using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Extensions.Services
{
    public static class ServiceExtension
    {
        public static void AddServiceExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddProblemDetails();
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.ConfigureCors();
            services.ConfigureSerilog();
            services.ConfigureIdentity();
            services.ConfigureDbContext(config);
            services.ConfigureOptions(config);
            services.ConfigureAuthentication(config);
            services.ConfigureAuthorization(config);
            services.ConfigureDependenciesInjections();
        }
    }
}