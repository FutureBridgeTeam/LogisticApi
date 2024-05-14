using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Domain.Entities;
using LogisticApi.Persistance.Contexts;
using LogisticApi.Persistance.Implementations.Repostories;
using LogisticApi.Persistance.Implementations.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));
            
            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 8;

                opt.User.RequireUniqueEmail = true;
                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                opt.Lockout.AllowedForNewUsers = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
            //Registrations of Repositories
            services.AddScoped<IServiceRepository,ServiceRepository>();
            services.AddScoped<IToCountryRepository,ToCountryRepository>();
            services.AddScoped<IFromCountryRepository,FromCountryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            //Registrations of Services
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IToCountryService, ToCountryService>();
            services.AddScoped<IFromCountryService,FromCountryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAutenticationService, AutenticationService>();
            return services;
        }

    }
}
