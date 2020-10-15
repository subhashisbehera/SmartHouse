using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SmartHouseDashBoard.Interfaces.Dtos;
using SmartHouseDashBoard.Interfaces.Models;
using SensorDto = SmartHouseDashBoard.Interfaces.Dtos.SensorDto;


namespace SmartHouseDashBoard.Services.Profiles
{
    public class SensorProfile:Profile
    {
        public SensorProfile()
        {
            CreateMap<RoomSensorMapping, SensorDto>()
                .ForMember(x => x.SensorName,
                    options => options.MapFrom(x => x.Sensor.SensorName))
                .ForMember(x => x.UnitOfMeasurement,
                    options => options.MapFrom(x => x.Sensor.UnitOfMeasurement));
        }
    }
}
