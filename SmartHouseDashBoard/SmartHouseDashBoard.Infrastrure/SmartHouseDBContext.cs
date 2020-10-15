using System;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartHouseDashBoard.Interfaces.Models;
using SmartHouseDashBoard.Persistence.Configurations;

namespace SmartHouseDashBoard.Persistence.Models
{
    public partial class SmartHouseDBContext : DbContext
    {
        public SmartHouseDBContext()
        {
        }

        public SmartHouseDBContext(DbContextOptions<SmartHouseDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomSensorMapping> RoomSensorMappings { get; set; }
        public virtual DbSet<Sensor> Sensors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseSqlServer("Server=.\\;Database=SmartHouse;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BuildingEntityConfigurations());
            modelBuilder.ApplyConfiguration(new FloorEntityConfigurations());
            modelBuilder.ApplyConfiguration(new SensorEntityConfigurations());
            modelBuilder.ApplyConfiguration(new RoomEntityConfigurations());
            modelBuilder.ApplyConfiguration(new RoomSensorMappingEntityConfigurations());
        }
    }
}
