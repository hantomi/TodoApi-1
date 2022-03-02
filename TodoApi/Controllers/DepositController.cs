using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.IRepository;
using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.Controllers
{
    [Route("api/v1/deposit")]
    [ApiController]
    public class DepositsController : ControllerBase
    {
        private readonly TnGContext _context;
        private IDepositRepository depositRepo;
        public DepositsController(TnGContext context)
        {
            this.depositRepo = new DepositRepository(context);
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Deposit>>> Get()
        {
            return Ok(await _context.Deposits.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Bicycle>>> Get(int Id)
        {
            var de = await _context.Deposits.FindAsync(Id);
            if (de == null)
                return BadRequest("not thing.");
            return Ok(de);
        }

        [HttpPost]
        public async Task<ActionResult<List<Deposit>>> Add(Deposit de)
        {
            _context.Deposits.Add(de);
            await _context.SaveChangesAsync();

            return Ok(await _context.Deposits.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Deposit>>> Update(Deposit request)
        {
            var de = await _context.Deposits.FindAsync(request.Id);
            if (de == null)
                return BadRequest("not thing.");

            de.Id = request.Id;
            de.Date = request.Date;
            de.Amount = request.Amount;
            de.Description = request.Description;
            de.UserId = request.UserId;
            de.TransactionId = request.TransactionId;

            await _context.SaveChangesAsync();

            return Ok(await _context.Deposits.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Deposit>>> Delete(int Id)
        {
            var de = await _context.Deposits.FindAsync(Id);
            if (de == null)
                return BadRequest("not thing.");

            _context.Deposits.Remove(de);
            await _context.SaveChangesAsync();

            return Ok(await _context.Deposits.ToListAsync());
        }
    }
}
