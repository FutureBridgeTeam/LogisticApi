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
    internal class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(70);
            builder.Property(x => x.Image)
                .IsRequired();
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(2000);
            builder.Property(x=>x.Icon)
                .IsRequired();
        }
    }
}
