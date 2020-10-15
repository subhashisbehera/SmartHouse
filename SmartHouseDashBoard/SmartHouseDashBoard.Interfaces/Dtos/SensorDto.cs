using System;
using System.Collections.Generic;

namespace SmartHouseDashBoard.Interfaces.Dtos
{
    public partial class SensorDto
    {
        public int SensorId { get; set; }
        public string SensorName { get; set; }
        public string UnitOfMeasurement { get; set; }
        public int Value { get; set; }
    }
}