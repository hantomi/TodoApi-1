using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.IRepository;
using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TnGContext _context;
        private ITransactionRepository transRepo;
        public TransactionController(TnGContext context)
        {
            this.transRepo = new TransactionRepository(context);
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> Get()
        {
            return Ok(await _context.Transactions.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Transaction>>> Get(int Id)
        {
            var trans = await _context.Transactions.FindAsync(Id);
            if (trans == null)
                return BadRequest("not thing.");
            return Ok(trans);
        }

        [HttpPost]
        public async Task<ActionResult<List<Transaction>>> Add(Transaction trans)
        {
            _context.Transactions.Add(trans);
            await _context.SaveChangesAsync();

            return Ok(await _context.Transactions.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Transaction>>> Update(Transaction request)
        {
            var trans = await _context.Transactions.FindAsync(request.Id);
            if (trans == null)
                return BadRequest("not thing.");

            trans.Id = request.Id;
            trans.Date = request.Date;
            trans.Amount = request.Amount;
            trans.Description = request.Description;
            trans.WalletId = request.WalletId;
            trans.DepositId = request.DepositId;

            await _context.SaveChangesAsync();

            return Ok(await _context.Transactions.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Transaction>>> Delete(int Id)
        {
            var trans = await _context.Transactions.FindAsync(Id);
            if (trans == null)
                return BadRequest("not thing.");

            _context.Transactions.Remove(trans);
            await _context.SaveChangesAsync();

            return Ok(await _context.Transactions.ToListAsync());
        }
    }
}
