using Microsoft.EntityFrameworkCore;
using TodoApi.IRepository;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class StationRepository : IStationRepository
    {
        private readonly TnGContext _context;
        public StationRepository (TnGContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            var s = await GetStation(id);
            s.Status = 4;
            _context.Stations.Update(s);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<Station> GetStation(int id)
        {
            var s = await _context.Stations.FindAsync(id);
            return s;
        }

        public async Task<IEnumerable<Station>> GetStations()
        {
            var ss = await _context.Stations.ToListAsync();
            return ss;
        }

        public async Task<int> InsertStation(Station station)
        {
            await _context.Stations.AddAsync(station);
            await _context.SaveChangesAsync();
            return station.Id;
        }

        public async Task<bool> UpdateStation(Station station)
        {
            _context.Stations.Update(station);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
