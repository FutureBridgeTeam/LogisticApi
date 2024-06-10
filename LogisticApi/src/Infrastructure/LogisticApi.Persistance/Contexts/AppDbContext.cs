using LogisticApi.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Service> Services { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<PartnerCompany> PartnerCompanies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ToCountry> ToCountries { get; set; }
        public DbSet<FromCountry> FromCountries { get; set; }
        public DbSet<CustomInfo> CustomInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
