using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHouseDashBoard.Interfaces.Dtos;
using SmartHouseDashBoard.Interfaces.Services;

namespace SmartHouseDashBoard.API.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly ILogger<DashBoardController> _logger;
        private readonly IDashBoardService _dashBoardService;
        public DashBoardController(IDashBoardService dashBoardService, ILogger<DashBoardController> logger)
        {
            _dashBoardService = dashBoardService;
            _logger = logger;
        }
        [HttpGet("buildings",Name = nameof(GetBuildings))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BuildingDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BuildingDto>>> GetBuildings()
        {
            var buildings = await _dashBoardService.GetAllBuildingsAsync();

            if (buildings == null)
                return NotFound("Buildings are not found");

            return Ok(buildings);
        }
        [HttpGet("buildings/{buildingId:int}/floors", Name = nameof(GetFloorsByBuilding))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(FloorDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<FloorDto>>> GetFloorsByBuilding(int buildingId)
        {
            var floors = await _dashBoardService.GetFloorsByBuildingIdAsync(buildingId);

            if (floors == null)
                return NotFound($"floors are not found for building id : {buildingId}");

            return Ok(floors);
        }
        [HttpGet("floors/{floorId:int}/rooms", Name = nameof(GetRoomsByFloor))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(RoomDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRoomsByFloor(int floorId)
        {
            var rooms = await _dashBoardService.GetRoomsByFloorIdAsync(floorId);

            if (rooms == null)
                return NotFound($"rooms are not found for floor  id : {floorId}");

            return Ok(rooms);
        }
        [HttpGet("rooms/{roomId:int}/sensors", Name = nameof(GetSensorsByFloor))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(SensorDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<SensorDto>>> GetSensorsByFloor(int roomId)
        {
            var rooms = await _dashBoardService.GetSensorsByRoomIdAsync(roomId);

            if (rooms == null)
                return NotFound($"sensors are not found for room  id : {roomId}");

            return Ok(rooms);
        }
    }
}
