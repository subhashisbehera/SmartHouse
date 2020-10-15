using System;
using System.Collections.Generic;

namespace SmartHouseDashBoard.Interfaces.Dtos
{
    public partial class BuildingDto
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public  IEnumerable<FloorDto> Floors { get; set; } 
    }
}
