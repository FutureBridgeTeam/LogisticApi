using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Domain.Entities;
using LogisticApi.Persistance.Contexts;
using LogisticApi.Persistance.Implementations.Repostories;
using LogisticApi.Persistance.Implementations.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Rewrite;
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
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUrlHelper>(x => x.GetRequiredService<IUrlHelperFactory>().GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext));
            //Registrations of Repositories
            services.AddScoped<IServiceRepository,ServiceRepository>();
            services.AddScoped<IToCountryRepository,ToCountryRepository>();
            services.AddScoped<IFromCountryRepository,FromCountryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IFaqRepository, FaqRepository>();
            services.AddScoped<IPartnerCompanyRepository, PartnerCompanyRepository>();
            services.AddScoped<ICustomInfoRepository, CustomInfoRepository>();
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<ILicenseRepository, LicenseRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IGalleryItemRepository, GalleryItemRepository>();
            //Registrations of Services
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IToCountryService, ToCountryService>();
            services.AddScoped<IFromCountryService,FromCountryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IFaqService, FaqService>();
            services.AddScoped<IPartnerCompanyService, PartnerCompanyService>();
            services.AddScoped<IAutenticationService, AutenticationService>();
            services.AddScoped<ICustomInfoService, CustomInfoService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<ILicenseService, LicenseService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IGalleryItemService, GalleryItemService>();
            return services;
        }

    }
}
