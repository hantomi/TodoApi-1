using Microsoft.EntityFrameworkCore;
using TodoApi.IRepository;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class TripRepository : ITripRepository
    {
        private readonly TnGContext _context;
        public TripRepository (TnGContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteTrip(int id)
        {
            var t = await _context.Trips.FindAsync(id);
            t.Status = 4;
            _context.Trips.Update(t);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<Trip> GetTrip(int id)
        {
            var t = await _context.Trips.FindAsync(id);
            return t;
        }

        public async Task<IEnumerable<Trip>> GetTrips()
        {
            var ts = await _context.Trips.ToListAsync();
            return ts;
        }

        public async Task<int> InsertTrip(Trip trip)
        {
            await _context.Trips.AddAsync(trip);
            await _context.SaveChangesAsync();
            return trip.Id;
        }

        public async Task<bool> UpdateTrip(Trip trip)
        {
            _context.Trips.Update(trip);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
