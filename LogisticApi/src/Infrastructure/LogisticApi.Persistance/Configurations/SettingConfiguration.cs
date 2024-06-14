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
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        void IEntityTypeConfiguration<Setting>.Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.Property(x => x.Key)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Value)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
