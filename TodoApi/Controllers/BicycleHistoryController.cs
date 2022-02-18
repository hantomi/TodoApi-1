using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicycleHistoryController : ControllerBase
    {
        private readonly DataContext _context;

        public BicycleHistoryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<BicycleHistory>>> Get()
        {
            return Ok(await _context.bicycleHistory.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<BicycleHistory>>> Get(int Id)
        {
            var BH = await _context.bicycleHistory.FindAsync(Id);
            if (BH == null)
                return BadRequest("not thing.");
            return Ok(BH);
        }

        [HttpPost]
        public async Task<ActionResult<List<BicycleHistory>>> Add(BicycleHistory xedap)
        {
            _context.bicycleHistory.Add(xedap);
            await _context.SaveChangesAsync();

            return Ok(await _context.bicycleHistory.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<BicycleHistory>>> Update(BicycleHistory request)
        {
            var xedap = await _context.bicycleHistory.FindAsync(request.Id);
            if (xedap == null)
                return BadRequest("not thing.");

            xedap.Id = request.Id;
            xedap.Description = request.Description;
            xedap.BicycleId = request.BicycleId;

            await _context.SaveChangesAsync();

            return Ok(await _context.bicycleHistory.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<BicycleHistory>>> Delete(int Id)
        {
            var BH = await _context.bicycleHistory.FindAsync(Id);
            if (BH == null)
                return BadRequest("not thing.");

            _context.bicycleHistory.Remove(BH);
            await _context.SaveChangesAsync();

            return Ok(await _context.bicycleHistory.ToListAsync());
        }
    }
}
