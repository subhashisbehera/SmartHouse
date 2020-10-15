using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHouseDashBoard.Interfaces.Models;

namespace SmartHouseDashBoard.Persistence.Configurations
{
  public   class BuildingEntityConfigurations:IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.ToTable("Building");
            builder.HasKey(e => e.BuildingId);

            builder.Property(e => e.BuildingName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
        }
    }
}
