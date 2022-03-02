using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TodoApi.IRepository;
using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.Controllers
{ 
    [ApiController]
    [Route("api/v1/bicycle")]
    public class BicyclesController : ControllerBase
    {
        private readonly TnGContext _context;
        private IBicycleRepository bicycleRepo;
        private IStationRepository stationRepo;
        public BicyclesController(TnGContext context)
        {
            this.bicycleRepo = new BicycleRepository(context);
            this.stationRepo = new StationRepository(context);
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Bicycle> Get(int status, int stationID, int page, int pageSize)
        {
            if(stationID == null)
            {
                IEnumerable<Bicycle> bs = bicycleRepo.GetBicycles().Where(b => b.Status.Equals(status));
            }
            return null;
        }

        [HttpGet(template:"get/{id}")]
        public Bicycle Get(int Id)
        {
            Bicycle b = bicycleRepo.GetBicycle(Id);
            return b;
        }

        [HttpPost(template:"add")]
        public String Add(Bicycle b)
        {
            bicycleRepo.InsertBicycle(b);

            return "Add Success";
        }

        [HttpPut(template:"update")]
        public String Update(Bicycle request)
        {
            try
            {
                bicycleRepo.UpdateBicycle(request);
            }
            catch (DataException)
            {
                return "Update Failed";
            }
            return "Update Success";
        }

        [HttpPut(template: "status-update")]
        public String UpdateStatus(Bicycle b, int status)
        {
            try
            {
                b.Status = status;
                bicycleRepo.UpdateBicycle(b);
            }
            catch (DataException)
            {
                return "Update Failed";
            }
            return "Update Success";
        }

        [HttpPut(template: "description-update")]
        public String DescStatus(Bicycle b, string desc)
        {
            try
            {
                b.Description = desc;
                bicycleRepo.UpdateBicycle(b);
            }
            catch (DataException)
            {
                return "Update Failed";
            }
            return "Update Success";
        }

        [HttpPut(template: "station-update")]
        public String StationStatus(Bicycle b, int stationId)
        {
            try
            {
                b.StationId = stationId;
                bicycleRepo.UpdateBicycle(b);
            }
            catch (DataException)
            {
                return "Update Failed";
            }
            return "Update Success";
        }

        [HttpDelete("{Id}")]
        public String Delete(int Id)
        {
            Bicycle b = bicycleRepo.GetBicycle(Id);
            if (b != null)
            {
                try
                {
                    bicycleRepo.DeleteBicycle(b.Id);
                    return "Delete Success";
                }
                catch (Exception)
                {
                    return "Delete Failed";
                }
            }
            return "Delete Failed";
        }
    }
}
