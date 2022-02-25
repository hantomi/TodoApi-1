using TodoApi.Models;

namespace TodoApi.IRepository
{
    public interface IBicycleTypeRepository
    {
        Task<IEnumerable<BicycleType>> GetBicycleTypes();
        Task<BicycleType> GetBicycleType(int id);
        Task Insert(BicycleType bicycleType);
        Task<bool> UpdateBicycleType(BicycleType bicycleType);
        Task<bool> DeleteBicycleType(int id);
    }
}
