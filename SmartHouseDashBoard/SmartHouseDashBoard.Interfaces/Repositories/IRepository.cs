using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseDashBoard.Interfaces.Repositories
{
   public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id); 
        Task AddRangeAsync(IEnumerable<T> entities);
        void UpdateRange(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<long> entityIds);
    }
}
