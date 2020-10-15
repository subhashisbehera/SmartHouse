using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartHouseDashBoard.Interfaces.Models;
using SmartHouseDashBoard.Interfaces.Repositories;
using SmartHouseDashBoard.Persistence.Models;

namespace SmartHouseDashBoard.Persistence.Repositories
{
    public class SensorRepository:ISensorRepository
    {
        private readonly SmartHouseDBContext _dbContext;

        public SensorRepository(SmartHouseDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<RoomSensorMapping>> GetAllAsync()
        {
            return await _dbContext.RoomSensorMappings.Include(s=>s.Sensor).AsNoTracking().ToListAsync();
        }

        public async Task<RoomSensorMapping> GetByIdAsync(int id)
        {
            return await _dbContext.RoomSensorMappings.Include(s => s.Sensor).AsNoTracking().FirstOrDefaultAsync(s => s.SensorId == id);
        }

        public Task AddRangeAsync(IEnumerable<RoomSensorMapping> entities)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<RoomSensorMapping> entities)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<long> entityIds)
        {
            throw new NotImplementedException();
        }

        public async  Task<IEnumerable<RoomSensorMapping>> GetByRoomIdAsync(int id)
        {
            return await _dbContext.RoomSensorMappings
                .Include(s => s.Sensor)
                .AsNoTracking().Where(s => s.RoomId == id).ToListAsync();

        }
    }
}
