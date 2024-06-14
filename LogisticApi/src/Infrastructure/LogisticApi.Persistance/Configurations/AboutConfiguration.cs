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
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        void IEntityTypeConfiguration<About>.Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(x => x.Tittle)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(2000);
            builder.Property(x => x.Image)
                .IsRequired();
        }
    }
}
