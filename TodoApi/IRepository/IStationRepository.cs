using TodoApi.Models;

namespace TodoApi.IRepository
{
    public interface IStationRepository
    {
        Task<IEnumerable<Station>> GetStations();
        Task<Station> GetStation(int id);
        Task<int> InsertStation(Station station);
        Task<bool> UpdateStation(Station station);
        Task<bool> Delete(int id);
    }
}
