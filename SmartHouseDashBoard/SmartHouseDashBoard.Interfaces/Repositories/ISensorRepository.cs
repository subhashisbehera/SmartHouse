using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SmartHouseDashBoard.Interfaces.Models;

namespace SmartHouseDashBoard.Interfaces.Repositories
{
    public interface ISensorRepository:IRepository<RoomSensorMapping>
    {
        Task<IEnumerable<RoomSensorMapping>> GetByRoomIdAsync(int id);
    }
}
