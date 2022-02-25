using TodoApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApi.IRepository
{
    public interface IBicycleRepository
    {
        Task<IEnumerable<Bicycle>> GetBicycles();
        Task<Bicycle> GetBicycle(int id);
        Task<int> InsertBicycle(Bicycle bicycle);
        Task<bool> UpdateBicycle(Bicycle bicycle);
        Task<bool> DeleteBicycle(int id);
    }
}
