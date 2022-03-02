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
        public Bicycle GetBicycle(int id)
        {
            return _context.Bicycles.Find(id);
           
       }

        public IEnumerable<Bicycle> GetBicycles()
        {
            var bs =  _context.Bicycles.Include(x => x.BicycleHistories).ToList();
            return bs;
        }

        public int InsertBicycle(Bicycle bicycle)
        {
             _context.Bicycles.AddAsync(bicycle);
             _context.SaveChangesAsync();
            return bicycle.Id;
        }

        public bool UpdateBicycle(Bicycle bicycle)
        {
            _context.Bicycles.Update(bicycle);
            int rows =  _context.SaveChanges();
            return rows > 0;
        }

        public bool DeleteBicycle(int id)
        {
            var b =  GetBicycle(id);
            b.Status = 4;
            _context.Bicycles.Update(b);
            int rows =  _context.SaveChanges();
            return rows > 0;
        }
    }
}
