using SmartHouseDashBoard.Interfaces.Models;
using SmartHouseDashBoard.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartHouseDashBoard.Persistence.Models;

namespace SmartHouseDashBoard.Persistence.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly SmartHouseDBContext _dbContext;

        public RoomRepository(SmartHouseDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task AddRangeAsync(IEnumerable<Room> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _dbContext.Rooms.AsNoTracking().ToListAsync();
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            return await _dbContext.Rooms.Include(r=>r.RoomSensorMappings)
                .ThenInclude(s=>s.Sensor)
                .AsNoTracking()
                .FirstOrDefaultAsync(f=>f.RoomId==id);
        }

        public void RemoveRange(IEnumerable<long> entityIds)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<Room> entities)
        {
            throw new NotImplementedException();
        }
    }
}
