using TodoApi.Models;

namespace TodoApi.IRepository
{
    public interface IBicycleHistoryRepository
    {
        Task<IEnumerable<BicycleHistory>> GetBicycleHistories();
        Task<BicycleHistory> GetBicycleHistory(int id);
        Task InsertBicycleHistory(BicycleHistory bicycleHistory);
        Task<bool> UpdateCategory(BicycleHistory bicycleHistory);
        Task<bool> DeleteBicycleHistory(int id);
    }
}
