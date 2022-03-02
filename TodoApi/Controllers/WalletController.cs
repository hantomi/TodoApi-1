using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.IRepository;
using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.Controllers
{
    [Route("api/v1/wallet")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly TnGContext _context;
        private IWalletRepository walletRepo;
        public WalletController(TnGContext context)
        {
            this.walletRepo = new WalletRepository(context);
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Wallet>>> Get()
        {
            return Ok(await _context.Wallets.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Wallet>>> Get(int Id)
        {
            var wa = await _context.Wallets.FindAsync(Id);
            if (wa == null)
                return BadRequest("not thing.");
            return Ok(wa);
        }

        [HttpPost]
        public async Task<ActionResult<List<Wallet>>> Add(Wallet wa)
        {
            _context.Wallets.Add(wa);
            await _context.SaveChangesAsync();

            return Ok(await _context.Wallets.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Wallet>>> Update(Wallet request)
        {
            var wa = await _context.Wallets.FindAsync(request.Id);
            if (wa == null)
                return BadRequest("not thing.");

            wa.Id = request.Id;
            wa.Money = request.Money;
            wa.Description = request.Description;
            wa.UserId = request.UserId;

            await _context.SaveChangesAsync();

            return Ok(await _context.Wallets.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Wallet>>> Delete(int Id)
        {
            var wa = await _context.Wallets.FindAsync(Id);
            if (wa == null)
                return BadRequest("not thing.");

            _context.Wallets.Remove(wa);
            await _context.SaveChangesAsync();

            return Ok(await _context.Wallets.ToListAsync());
        }
    }
}
