using TodoApi.Models;

namespace TodoApi.IRepository
{
    public interface ITripRepository
    {
        Task<IEnumerable<Trip>> GetTrips();
        Task<Trip> GetTrip(int id);
        Task<int> InsertTrip(Trip trip);
        Task<bool> UpdateTrip(Trip trip);
        Task<bool> DeleteTrip(int id);
    }
}
