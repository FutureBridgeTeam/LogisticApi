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
    internal class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(x => x.Location)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(x => x.Web)
                .HasMaxLength(100);
            builder.Property(x => x.Image)
                .IsRequired();

        }
    }
}
