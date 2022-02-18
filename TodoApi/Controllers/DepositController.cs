using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly DataContext _context;

        public DepositController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Deposit>>> Get()
        {
            return Ok(await _context.deposit.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Bicycles>>> Get(int Id)
        {
            var de = await _context.deposit.FindAsync(Id);
            if (de == null)
                return BadRequest("not thing.");
            return Ok(de);
        }

        [HttpPost]
        public async Task<ActionResult<List<Deposit>>> Add(Deposit de)
        {
            _context.deposit.Add(de);
            await _context.SaveChangesAsync();

            return Ok(await _context.deposit.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Deposit>>> Update(Deposit request)
        {
            var de = await _context.deposit.FindAsync(request.Id);
            if (de == null)
                return BadRequest("not thing.");

            de.Id = request.Id;
            de.Date = request.Date;
            de.Amount = request.Amount;
            de.Description = request.Description;
            de.UserId = request.UserId;
            de.TransactionId = request.TransactionId;

            await _context.SaveChangesAsync();

            return Ok(await _context.deposit.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Deposit>>> Delete(int Id)
        {
            var de = await _context.deposit.FindAsync(Id);
            if (de == null)
                return BadRequest("not thing.");

            _context.deposit.Remove(de);
            await _context.SaveChangesAsync();

            return Ok(await _context.deposit.ToListAsync());
        }
    }
}
