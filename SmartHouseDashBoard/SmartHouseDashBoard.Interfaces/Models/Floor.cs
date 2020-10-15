using System;
using System.Collections.Generic;

namespace SmartHouseDashBoard.Interfaces.Models
{
    public partial class Floor
    {
        public int FloorId { get; set; }
        public string FloorName { get; set; }
        public int BuildingId { get; set; }

        public virtual Building Building { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }= new List<Room>();
    }
}
