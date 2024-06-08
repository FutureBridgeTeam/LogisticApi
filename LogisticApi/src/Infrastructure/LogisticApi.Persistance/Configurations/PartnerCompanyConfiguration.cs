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
    internal class PartnerCompanyConfiguration : IEntityTypeConfiguration<PartnerCompany>
    {
        public void Configure(EntityTypeBuilder<PartnerCompany> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(75);
            builder.Property(x => x.WebsiteLink)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(x => x.Image)
                .IsRequired();
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(1500);
        }
    }
}
