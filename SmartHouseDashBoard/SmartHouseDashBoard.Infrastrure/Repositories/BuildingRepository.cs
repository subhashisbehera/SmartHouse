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
    public class BuildingRepository : IBuildingRepository
    {
        private readonly SmartHouseDBContext _dbContext;

        public BuildingRepository(SmartHouseDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task AddRangeAsync(IEnumerable<Building> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Building>> GetAllAsync()
        {
            return await _dbContext.Buildings.Include(f => f.Floors).AsNoTracking().ToListAsync();
        }

        public async Task<Building> GetByIdAsync(int id)
        {
            return await _dbContext.Buildings.Include(f => f.Floors).FirstOrDefaultAsync(f => f.BuildingId == id);
        }

        public void RemoveRange(IEnumerable<long> entityIds)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<Building> entities)
        {
            throw new NotImplementedException();
        }
    }
}
