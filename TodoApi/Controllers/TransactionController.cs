using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly DataContext _context;

        public TransactionController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> Get()
        {
            return Ok(await _context.transaction.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Transaction>>> Get(int Id)
        {
            var trans = await _context.transaction.FindAsync(Id);
            if (trans == null)
                return BadRequest("not thing.");
            return Ok(trans);
        }

        [HttpPost]
        public async Task<ActionResult<List<Transaction>>> Add(Transaction trans)
        {
            _context.transaction.Add(trans);
            await _context.SaveChangesAsync();

            return Ok(await _context.transaction.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Transaction>>> Update(Transaction request)
        {
            var trans = await _context.transaction.FindAsync(request.Id);
            if (trans == null)
                return BadRequest("not thing.");

            trans.Id = request.Id;
            trans.Date = request.Date;
            trans.Amount = request.Amount;
            trans.Description = request.Description;
            trans.WalletId = request.WalletId;
            trans.DepositId = request.DepositId;

            await _context.SaveChangesAsync();

            return Ok(await _context.transaction.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Transaction>>> Delete(int Id)
        {
            var trans = await _context.transaction.FindAsync(Id);
            if (trans == null)
                return BadRequest("not thing.");

            _context.transaction.Remove(trans);
            await _context.SaveChangesAsync();

            return Ok(await _context.transaction.ToListAsync());
        }
    }
}
