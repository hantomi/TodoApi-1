using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{ 
    [ApiController]
    [Route("api/v1/bicycle")]
    public class BicyclesController : ControllerBase
    {
        private readonly TnGContext _context;

        public BicyclesController(TnGContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Bicycle>>> Get()
        {
            return Ok(await _context.Bicycles.ToListAsync()); 
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Bicycle>>> Get(int Id)
        {
            //IEnumerable<Company> companies = companyRepository.GetCompanies().Skip(page * pagesize).Take(pagesize)
            //    .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            var b = await _context.Bicycles.FindAsync(Id);
            if (b == null)
                return BadRequest("not thing.");
            return Ok(b);
        }

        [HttpPost]
        public async Task<ActionResult<List<Bicycle>>> Add(Bicycle b)
        {
            _context.Bicycles.Add(b);
            await _context.SaveChangesAsync();

            return Ok(await _context.Bicycles.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Bicycle>>> Update(Bicycle request)
        {
            var b = await _context.Bicycles.FindAsync(request.Id);
            if (b == null)
                return BadRequest("not thing.");

            b.Id = request.Id;
            b.Status = request.Status;
            b.Description = request.Description;
            b.StationId = request.StationId;
            b.LicensePlate = request.LicensePlate;

            await _context.SaveChangesAsync();

            return Ok(await _context.Bicycles.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Bicycle>>> Delete(int Id)
        {
            var b = await _context.Bicycles.FindAsync(Id);
            if (b == null)
                return BadRequest("not thing.");

            _context.Bicycles.Remove(b);
            await _context.SaveChangesAsync();

            return Ok(await _context.Bicycles.ToListAsync());
        }
    }
}
