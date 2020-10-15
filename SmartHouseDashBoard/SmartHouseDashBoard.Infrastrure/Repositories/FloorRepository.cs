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
    public class FloorRepository : IFloorRepository
    {
        private readonly SmartHouseDBContext _dbContext;

        public FloorRepository(SmartHouseDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task AddRangeAsync(IEnumerable<Floor> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Floor>> GetAllAsync()
        {
            return await _dbContext.Floors.AsNoTracking().ToListAsync();
        }

        public async Task<Floor> GetByIdAsync(int id)
        {
            return await _dbContext.Floors.Include(r=>r.Rooms).AsNoTracking().FirstOrDefaultAsync(f=>f.FloorId==id);
        }

        public void RemoveRange(IEnumerable<long> entityIds)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<Floor> entities)
        {
            throw new NotImplementedException();
        }
    }
}
