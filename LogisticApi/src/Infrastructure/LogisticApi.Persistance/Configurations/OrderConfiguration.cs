using LogisticApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.CompanyName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.CompanyEmail)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.CompanyPhone)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(x => x.LoadName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.LoadWeight)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(o => o.LoadCapasity)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(x => x.TrackingId)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x => x.Status)
                .IsRequired();
            builder.Property(x => x.ToCountryId)
            .IsRequired(false);
            builder.Property(x => x.FromCountryId)
            .IsRequired(false);
            builder.Property(x => x.ServiceId)
            .IsRequired(false);
            builder.Property(x=>x.AppUserId) 
                .IsRequired(false);
        }
    }
}
