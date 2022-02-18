using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicyclesController : ControllerBase
    {
        private readonly DataContext _context;

        public BicyclesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Bicycles>>> Get()
        {
            return Ok(await _context.Bicycle.ToListAsync()); 
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Bicycles>>> Get(int Id)
        {
            var xedap = await _context.Bicycle.FindAsync(Id);
            if (xedap == null)
                return BadRequest("not thing.");
            return Ok(xedap);
        }

        [HttpPost]
        public async Task<ActionResult<List<Bicycles>>> Add(Bicycles xedap)
        {
            _context.Bicycle.Add(xedap);
            await _context.SaveChangesAsync();

            return Ok(await _context.Bicycle.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Bicycles>>> Update(Bicycles request)
        {
            var xedap = await _context.Bicycle.FindAsync(request.Id);
            if (xedap == null)
                return BadRequest("not thing.");

            xedap.Id = request.Id;
            xedap.Status = request.Status;
            xedap.Description = request.Description;
            xedap.StationId = request.StationId;
            xedap.LicensePlate = request.LicensePlate;

            await _context.SaveChangesAsync();

            return Ok(await _context.Bicycle.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Bicycles>>> Delete(int Id)
        {
            var xedap = await _context.Bicycle.FindAsync(Id);
            if (xedap == null)
                return BadRequest("not thing.");

            _context.Bicycle.Remove(xedap);
            await _context.SaveChangesAsync();

            return Ok(await _context.Bicycle.ToListAsync());
        }
    }
}
