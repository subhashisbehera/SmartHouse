using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SmartHouseDashBoard.Interfaces.Dtos;
using SmartHouseDashBoard.Interfaces.Repositories;
using SmartHouseDashBoard.Interfaces.Services;

namespace SmartHouseDashBoard.Services.Services
{
    public class DashBoardService:IDashBoardService
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IFloorRepository _floorRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly ISensorRepository _sensorRepository;
        private readonly ILogger<DashBoardService> _logger;
        private readonly IMapper _mapper;
        public DashBoardService(IBuildingRepository buildingRepository, IFloorRepository floorRepository, IRoomRepository roomRepository, ISensorRepository sensorRepository, ILogger<DashBoardService> logger, IMapper mapper)
        {
                _buildingRepository = buildingRepository;
                _floorRepository = floorRepository;
                _roomRepository = roomRepository;
               _sensorRepository = sensorRepository;
               _logger = logger;
               _mapper = mapper;
        }
        public async Task<IEnumerable<BuildingDto>> GetAllBuildingsAsync()
        {
            IEnumerable<BuildingDto> buildings;
            try
            {
             var buildingsFormDb= await _buildingRepository.GetAllAsync();
              buildings = _mapper.Map<IEnumerable<BuildingDto>>(buildingsFormDb);
            }
            catch (Exception ex)
            {
              _logger.LogError(ex.Message);
               return null;
            }
            return buildings;
        }

        public async Task<BuildingDto> GetBuildingByIdAsync(int id)
        {
            BuildingDto building;
            try
            {
                var buildingFormDb = await _buildingRepository.GetByIdAsync(id);
                building = _mapper.Map<BuildingDto>(buildingFormDb);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
            return building;
        }

        public async Task<IEnumerable<FloorDto>> GetAllFloorsAsync()
        {
            IEnumerable<FloorDto> floors;
            try
            {
                var floorsFromDb = await _floorRepository.GetAllAsync();
                floors = _mapper.Map<IEnumerable<FloorDto>>(floorsFromDb);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
            return floors;
        }

        public async Task<IEnumerable<FloorDto>> GetFloorsByBuildingIdAsync(int buildingId)
        {
            IEnumerable<FloorDto> floors;
            try
            {
                var floorsFromDb = await _buildingRepository.GetByIdAsync(buildingId);
                floors = _mapper.Map<IEnumerable<FloorDto>>(floorsFromDb.Floors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
            return floors;
        }

        public async Task<IEnumerable<RoomDto>> GetRoomsByFloorIdAsync(int floorId)
        {
            IEnumerable<RoomDto> rooms;
            try
            {
                var roomsFromDb = await _floorRepository.GetByIdAsync(floorId);
                rooms = _mapper.Map<IEnumerable<RoomDto>>(roomsFromDb.Rooms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
            return rooms;
        }

        public async Task<IEnumerable<SensorDto>> GetSensorsByRoomIdAsync(int roomId)
        {
            IEnumerable<SensorDto> sensors;
            try
            {
                var sensorFromDb = await _sensorRepository.GetByRoomIdAsync(roomId);
                sensors = _mapper.Map<IEnumerable<SensorDto>>(sensorFromDb);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
            return sensors;
        }
    }
}
