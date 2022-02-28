using Microsoft.EntityFrameworkCore;
using TodoApi.IRepository;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class BicycleTypeRepository : IBicycleTypeRepository
    {
        private readonly TnGContext _context;
        public BicycleTypeRepository (TnGContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteBicycleType(int id)
        {
            var d = await _context.BicycleTypes.FindAsync(id);
            _context.BicycleTypes.Remove(d);
            return true;
        }

        public async Task<BicycleType> GetBicycleType(int id)
        {
            var b = await _context.BicycleTypes.FindAsync(id);
            return b;
        }

        public async Task<IEnumerable<BicycleType>> GetBicycleTypes()
        {
            var bs = await _context.BicycleTypes.ToListAsync();
            return bs;
        }

        public async Task Insert(BicycleType bicycleType)
        {
            await _context.BicycleTypes.AddAsync(bicycleType);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateBicycleType(BicycleType bicycleType)
        {
            _context.BicycleTypes.Update(bicycleType);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
