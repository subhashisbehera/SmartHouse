using System;
using System.Collections.Generic;
using SmartHouseDashBoard.Interfaces.Models;

namespace SmartHouseDashBoard.Interfaces.Models
{
    public partial class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int FloorId { get; set; }

        public virtual Floor Floor { get; set; }
        public virtual ICollection<RoomSensorMapping> RoomSensorMappings { get; set; }= new List<RoomSensorMapping>();
    }
}
