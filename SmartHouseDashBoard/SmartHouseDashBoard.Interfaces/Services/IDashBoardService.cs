using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SmartHouseDashBoard.Interfaces.Dtos;

namespace SmartHouseDashBoard.Interfaces.Services
{
    public interface IDashBoardService
    {
        Task<IEnumerable<BuildingDto>> GetAllBuildingsAsync();
        Task<BuildingDto> GetBuildingByIdAsync(int id);
        Task<IEnumerable<FloorDto>> GetAllFloorsAsync();
        Task<IEnumerable<FloorDto>> GetFloorsByBuildingIdAsync(int buildingId);
        Task<IEnumerable<RoomDto>> GetRoomsByFloorIdAsync(int floorId);
        Task<IEnumerable<SensorDto>> GetSensorsByRoomIdAsync(int roomId);
    }
}
