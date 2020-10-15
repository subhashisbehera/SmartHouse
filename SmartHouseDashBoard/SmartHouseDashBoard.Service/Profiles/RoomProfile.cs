using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SmartHouseDashBoard.Interfaces.Dtos;
using SmartHouseDashBoard.Interfaces.Models;


namespace SmartHouseDashBoard.Services.Profiles
{
    public class RoomProfile:Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDto>().ReverseMap();
        }
    }
}
