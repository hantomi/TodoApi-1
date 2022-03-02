using TodoApi.IRepository;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class BicycleHistoryRepository : IBicycleHistoryRepository
    {
        private readonly TnGContext _context;
        public BicycleHistoryRepository (TnGContext context)
        {
            _context = context;
        }
        public Task<bool> DeleteBicycleHistory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BicycleHistory>> GetBicycleHistories()
        {
            throw new NotImplementedException();
        }

        public Task<BicycleHistory> GetBicycleHistory(int id)
        {
            throw new NotImplementedException();
        }

        public Task InsertBicycleHistory(BicycleHistory bicycleHistory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategory(BicycleHistory bicycleHistory)
        {
            throw new NotImplementedException();
        }
    }
}
