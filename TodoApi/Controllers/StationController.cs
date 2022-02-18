using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly DataContext _context;

        public StationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Station>>> Get()
        {
            return Ok(await _context.station.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Station>>> Get(int Id)
        {
            var sta = await _context.station.FindAsync(Id);
            if (sta == null)
                return BadRequest("not thing.");
            return Ok(sta);
        }

        [HttpPost]
        public async Task<ActionResult<List<Station>>> Add(Station sta)
        {
            _context.station.Add(sta);
            await _context.SaveChangesAsync();

            return Ok(await _context.station.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Station>>> Update(Station request)
        {
            var sta = await _context.station.FindAsync(request.Id);
            if (sta == null)
                return BadRequest("not thing.");

            sta.Id = request.Id;
            sta.Location = request.Location;
            sta.Capability = request.Capability;
            sta.Status = request.Status;

            await _context.SaveChangesAsync();

            return Ok(await _context.station.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Station>>> Delete(int Id)
        {
            var sta = await _context.station.FindAsync(Id);
            if (sta == null)
                return BadRequest("not thing.");

            _context.station.Remove(sta);
            await _context.SaveChangesAsync();

            return Ok(await _context.station.ToListAsync());
        }
    }
}
