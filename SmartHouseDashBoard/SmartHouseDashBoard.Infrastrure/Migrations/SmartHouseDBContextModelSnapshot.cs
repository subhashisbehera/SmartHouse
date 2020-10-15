﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartHouseDashBoard.Persistence.Models;

namespace SmartHouseDashBoard.Persistence.Migrations
{
    [DbContext(typeof(SmartHouseDBContext))]
    partial class SmartHouseDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartHouseDashBoard.Interfaces.Models.Building", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BuildingName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("BuildingId");

                    b.ToTable("Building");
                });

            modelBuilder.Entity("SmartHouseDashBoard.Interfaces.Models.Floor", b =>
                {
                    b.Property<int>("FloorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<string>("FloorName")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("FloorId");

                    b.HasIndex("BuildingId");

                    b.ToTable("Floor");
                });

            modelBuilder.Entity("SmartHouseDashBoard.Interfaces.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FloorId")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("RoomId");

                    b.HasIndex("FloorId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("SmartHouseDashBoard.Interfaces.Models.RoomSensorMapping", b =>
                {
                    b.Property<int>("RoomSensorMappingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("SensorId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("RoomSensorMappingId");

                    b.HasIndex("RoomId");

                    b.HasIndex("SensorId");

                    b.ToTable("Room_Sensor_Mapping");
                });

            modelBuilder.Entity("SmartHouseDashBoard.Interfaces.Models.Sensor", b =>
                {
                    b.Property<int>("SensorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SensorName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("UnitOfMeasurement")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("SensorId");

                    b.ToTable("Sensor");
                });

            modelBuilder.Entity("SmartHouseDashBoard.Interfaces.Models.Floor", b =>
                {
                    b.HasOne("SmartHouseDashBoard.Interfaces.Models.Building", "Building")
                        .WithMany("Floors")
                        .HasForeignKey("BuildingId")
                        .HasConstraintName("FK_Floor_Building")
                        .IsRequired();
                });

            modelBuilder.Entity("SmartHouseDashBoard.Interfaces.Models.Room", b =>
                {
                    b.HasOne("SmartHouseDashBoard.Interfaces.Models.Floor", "Floor")
                        .WithMany("Rooms")
                        .HasForeignKey("FloorId")
                        .HasConstraintName("FK_Room_Floor")
                        .IsRequired();
                });

            modelBuilder.Entity("SmartHouseDashBoard.Interfaces.Models.RoomSensorMapping", b =>
                {
                    b.HasOne("SmartHouseDashBoard.Interfaces.Models.Room", "Room")
                        .WithMany("RoomSensorMappings")
                        .HasForeignKey("RoomId")
                        .HasConstraintName("FK_Room_Sensor_Mapping_Room")
                        .IsRequired();

                    b.HasOne("SmartHouseDashBoard.Interfaces.Models.Sensor", "Sensor")
                        .WithMany("RoomSensorMappings")
                        .HasForeignKey("SensorId")
                        .HasConstraintName("FK_Room_Sensor_Mapping_Sensor")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
