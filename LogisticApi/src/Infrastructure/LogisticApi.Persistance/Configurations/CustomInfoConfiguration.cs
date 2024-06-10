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
    public class CustomInfoConfiguration : IEntityTypeConfiguration<CustomInfo>
    {
        public void Configure(EntityTypeBuilder<CustomInfo> builder)
        {
            builder.Property(x => x.Tittle)
                .IsRequired()
                .HasMaxLength(70);
            builder.Property(x => x.Image)
                .IsRequired();
        }
    }
}
