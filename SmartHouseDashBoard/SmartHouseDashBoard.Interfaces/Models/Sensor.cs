using System;
using System.Collections.Generic;

namespace SmartHouseDashBoard.Interfaces.Models
{
    public partial class Sensor
    {
        public int SensorId { get; set; }
        public string SensorName { get; set; }
        public string UnitOfMeasurement { get; set; }

        public virtual ICollection<RoomSensorMapping> RoomSensorMappings { get; set; }= new List<RoomSensorMapping>();
    }
}
