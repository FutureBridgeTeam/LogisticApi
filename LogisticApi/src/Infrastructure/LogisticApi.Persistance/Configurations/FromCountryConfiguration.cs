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
    internal class FromCountryConfiguration : IEntityTypeConfiguration<FromCountry>
    {
        public void Configure(EntityTypeBuilder<FromCountry> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(70);
        }
    }
}
