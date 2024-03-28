using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Infrastructure.Implementations.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Infrastructure.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ICloudinaryService,CloudinaryService>(); 
            return services;    
        }
    }
}
