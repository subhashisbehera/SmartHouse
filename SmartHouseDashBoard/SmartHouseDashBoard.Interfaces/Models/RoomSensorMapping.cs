using System;
using System.Collections.Generic;
using SmartHouseDashBoard.Interfaces.Models;

namespace SmartHouseDashBoard.Interfaces.Models
{
    public partial class RoomSensorMapping
    {
        public int RoomSensorMappingId { get; set; }
        public int RoomId { get; set; }
        public int SensorId { get; set; }
        public int Value { get; set; }

        public virtual Room Room { get; set; }
        public virtual Sensor Sensor { get; set; }
    }
}
