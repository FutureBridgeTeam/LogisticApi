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
    internal class ToCountryConfiguration : IEntityTypeConfiguration<ToCountry>
    {
        public void Configure(EntityTypeBuilder<ToCountry> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(70);

        }
    }
}
