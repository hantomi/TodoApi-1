using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicycleTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public BicycleTypesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<BicycleType>>> Get()
        {
            return Ok(await _context.bicycleType.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<BicycleType>>> Get(int Id)
        {
            var xedap = await _context.bicycleType.FindAsync(Id);
            if (xedap == null)
                return BadRequest("not thing.");
            return Ok(xedap);
        }

        [HttpPost]
        public async Task<ActionResult<List<BicycleType>>> Add(BicycleType xedap)
        {
            _context.bicycleType.Add(xedap);
            await _context.SaveChangesAsync();

            return Ok(await _context.bicycleType.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<BicycleType>>> Update(BicycleType request)
        {
            var xedap = await _context.bicycleType.FindAsync(request.Id);
            if (xedap == null)
                return BadRequest("not thing.");

            xedap.Id = request.Id;
            xedap.Type = request.Type;
            xedap.BicycleId = request.BicycleId;
            xedap.DateAdded = request.DateAdded;
            xedap.Color = request.Color;

            await _context.SaveChangesAsync();

            return Ok(await _context.bicycleType.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<BicycleType>>> Delete(int Id)
        {
            var xedap = await _context.bicycleType.FindAsync(Id);
            if (xedap == null)
                return BadRequest("not thing.");

            _context.bicycleType.Remove(xedap);
            await _context.SaveChangesAsync();

            return Ok(await _context.bicycleType.ToListAsync());
        }
    }
}
