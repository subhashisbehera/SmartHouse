using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHouseDashBoard.Interfaces.Models;

namespace SmartHouseDashBoard.Persistence.Configurations
{
  public   class SensorEntityConfigurations : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.ToTable("Sensor");
            builder.HasKey(e => e.SensorId);
            builder.Property(e => e.SensorName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);  

            builder.Property(e => e.UnitOfMeasurement)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
