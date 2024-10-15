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
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.Property(x => x.Tittle)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(5000);
            builder.Property(x => x.Image)
                .IsRequired();
        }
    }
}
