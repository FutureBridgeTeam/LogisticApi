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
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(x => x.ProfileImage)
                .IsRequired();
            builder.Property(x=>x.BirthDate)
                .IsRequired();
            builder.Property(x => x.Gender)
                .IsRequired();
        }
    }
}
