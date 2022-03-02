using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.IRepository;
using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.Controllers
{
    [Route("api/v1/station")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly TnGContext _context;
        private IStationRepository stationRepo;
        public StationController(TnGContext context)
        {
            this.stationRepo = new StationRepository(context);
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Station> Get()
        {
            return stationRepo.GetStations().ToList();
        }

        [HttpGet("{id}")]
        public Station Get(int Id)
        {
            return stationRepo.GetStation(Id);
        }

        [HttpPost(template:"add")]
        public String Add(Station sta)
        {
            try
            {
                stationRepo.InsertStation(sta);
                return "Add Success";
            }
            catch (Exception)
            {
                return "Add Failed";
            }
            return "Add Failed";
        }

        [HttpPut(template:"update")]
        public String Update(Station request)
        {
            try
            {
                stationRepo.UpdateStation(request);
            }
            catch (Exception)
            {
                return "Update Failed";
            }
            return "Update Failed";
        }

        [HttpDelete(template:"delete/{id}")]
        public String Delete(int Id)
        {
            try
            {
                stationRepo.Delete(Id);
                return "Delete Success";
            }
            catch (Exception)
            {
                return "Delete Failed.";
            }
            return "Delete Failed";
        }
    }
}
