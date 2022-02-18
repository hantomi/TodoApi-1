using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly DataContext _context;

        public TripController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Trip>>> Get()
        {
            return Ok(await _context.trip.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Trip>>> Get(int Id)
        {
            var tr = await _context.trip.FindAsync(Id);
            if (tr == null)
                return BadRequest("not thing.");
            return Ok(tr);
        }

        [HttpPost]
        public async Task<ActionResult<List<Trip>>> Add(Trip tr)
        {
            _context.trip.Add(tr);
            await _context.SaveChangesAsync();

            return Ok(await _context.trip.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Trip>>> Update(Trip request)
        {
            var tr = await _context.trip.FindAsync(request.Id);
            if (tr == null)
                return BadRequest("not thing.");

            tr.Id = request.Id;
            tr.BeginTime = request.BeginTime;
            tr.EndTime = request.EndTime;
            tr.StationStartId = request.StationStartId;
            tr.BicycleId = request.BicycleId;
            tr.StationEndId = request.StationEndId;
            tr.Status = request.Status;

            await _context.SaveChangesAsync();

            return Ok(await _context.trip.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Trip>>> Delete(int Id)
        {
            var tr = await _context.trip.FindAsync(Id);
            if (tr == null)
                return BadRequest("not thing.");

            _context.trip.Remove(tr);
            await _context.SaveChangesAsync();

            return Ok(await _context.trip.ToListAsync());
        }
    }
}
