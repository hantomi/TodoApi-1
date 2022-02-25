using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/v1/station")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly TnGContext _context;

        public StationController(TnGContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Station>>> Get()
        {
            return Ok(await _context.Stations.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Station>>> Get(int Id)
        {
            var sta = await _context.Stations.FindAsync(Id);
            if (sta == null)
                return BadRequest("not thing.");
            return Ok(sta);
        }

        [HttpPost]
        public async Task<ActionResult<List<Station>>> Add(Station sta)
        {
            _context.Stations.Add(sta);
            await _context.SaveChangesAsync();

            return Ok(await _context.Stations.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Station>>> Update(Station request)
        {
            var sta = await _context.Stations.FindAsync(request.Id);
            if (sta == null)
                return BadRequest("not thing.");

            sta.Id = request.Id;
            sta.Location = request.Location;
            sta.Capability = request.Capability;
            sta.Status = request.Status;

            await _context.SaveChangesAsync();

            return Ok(await _context.Stations.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Station>>> Delete(int Id)
        {
            var sta = await _context.Stations.FindAsync(Id);
            if (sta == null)
                return BadRequest("not thing.");

            _context.Stations.Remove(sta);
            await _context.SaveChangesAsync();

            return Ok(await _context.Stations.ToListAsync());
        }
    }
}
