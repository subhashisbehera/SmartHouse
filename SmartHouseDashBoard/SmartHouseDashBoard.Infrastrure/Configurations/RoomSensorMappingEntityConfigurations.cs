using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHouseDashBoard.Interfaces.Models;

namespace SmartHouseDashBoard.Persistence.Configurations
{
  public   class RoomSensorMappingEntityConfigurations : IEntityTypeConfiguration<RoomSensorMapping>
    {
        public void Configure(EntityTypeBuilder<RoomSensorMapping> builder)
        {
            
            builder.HasKey(e => e.RoomSensorMappingId);

            builder.ToTable("Room_Sensor_Mapping");

            builder.Property(e => e.Value);

            builder.HasOne(d => d.Room)
                .WithMany(p => p.RoomSensorMappings)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Room_Sensor_Mapping_Room");

            builder.HasOne(d => d.Sensor)
                .WithMany(p => p.RoomSensorMappings)
                .HasForeignKey(d => d.SensorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Room_Sensor_Mapping_Sensor");
        }
    }
}
