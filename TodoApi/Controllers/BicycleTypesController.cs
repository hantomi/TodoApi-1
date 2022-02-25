using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/v1/bicycle-type")]
    [ApiController]
    public class BicycleTypesController : ControllerBase
    {
        private readonly TnGContext _context;

        public BicycleTypesController(TnGContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<BicycleType>>> Get()
        {
            return Ok(await _context.BicycleTypes.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<BicycleType>>> Get(int Id)
        {
            var xedap = await _context.BicycleTypes.FindAsync(Id);
            if (xedap == null)
                return BadRequest("not thing.");
            return Ok(xedap);
        }

        [HttpPost]
        public async Task<ActionResult<List<BicycleType>>> Add(BicycleType xedap)
        {
            _context.BicycleTypes.Add(xedap);
            await _context.SaveChangesAsync();

            return Ok(await _context.BicycleTypes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<BicycleType>>> Update(BicycleType request)
        {
            var xedap = await _context.BicycleTypes.FindAsync(request.Id);
            if (xedap == null)
                return BadRequest("not thing.");

            xedap.Id = request.Id;
            xedap.Type = request.Type;
            xedap.BicycleId = request.BicycleId;
            xedap.DateAdded = request.DateAdded;
            xedap.Color = request.Color;

            await _context.SaveChangesAsync();

            return Ok(await _context.BicycleTypes.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<BicycleType>>> Delete(int Id)
        {
            var xedap = await _context.BicycleTypes.FindAsync(Id);
            if (xedap == null)
                return BadRequest("not thing.");

            _context.BicycleTypes.Remove(xedap);
            await _context.SaveChangesAsync();

            return Ok(await _context.BicycleTypes.ToListAsync());
        }
    }
}
