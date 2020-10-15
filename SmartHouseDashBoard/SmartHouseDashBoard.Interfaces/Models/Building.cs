using System;
using System.Collections.Generic;

namespace SmartHouseDashBoard.Interfaces.Models
{
    public partial class Building
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }

        public virtual ICollection<Floor> Floors { get; set; } =new List<Floor>();
    }
}
