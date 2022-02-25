using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using TodoApi.IRepository;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class BicycleRepository : IBicycleRepository
    {
        private readonly TnGContext _context;
        public BicycleRepository (TnGContext context)
        {
            _context = context;
        }
        public async Task<Bicycle> GetBicycle(int id)
        {
            var b = await _context.Bicycles.FindAsync(id);
            return b;
       }

        public async Task<IEnumerable<Bicycle>> GetBicycles()
        {
            var bs = await _context.Bicycles.Include(x => x.BicycleHistories).ToListAsync();
            return bs;
        }

        public async Task<int> InsertBicycle(Bicycle bicycle)
        {
            await _context.Bicycles.AddAsync(bicycle);
            await _context.SaveChangesAsync();
            return bicycle.Id;
        }

        public async Task<bool> UpdateBicycle(Bicycle bicycle)
        {
            _context.Bicycles.Update(bicycle);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        async Task<bool> IBicycleRepository.DeleteBicycle(int id)
        {
            var b = await GetBicycle(id);
            b.Status = 4;
            _context.Bicycles.Update(b);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
