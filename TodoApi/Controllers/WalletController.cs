using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly DataContext _context;

        public WalletController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Wallet>>> Get()
        {
            return Ok(await _context.wallet.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Wallet>>> Get(int Id)
        {
            var wa = await _context.wallet.FindAsync(Id);
            if (wa == null)
                return BadRequest("not thing.");
            return Ok(wa);
        }

        [HttpPost]
        public async Task<ActionResult<List<Wallet>>> Add(Wallet wa)
        {
            _context.wallet.Add(wa);
            await _context.SaveChangesAsync();

            return Ok(await _context.wallet.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Wallet>>> Update(Wallet request)
        {
            var wa = await _context.wallet.FindAsync(request.Id);
            if (wa == null)
                return BadRequest("not thing.");

            wa.Id = request.Id;
            wa.Money = request.Money;
            wa.Description = request.Description;
            wa.UserId = request.UserId;

            await _context.SaveChangesAsync();

            return Ok(await _context.wallet.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Wallet>>> Delete(int Id)
        {
            var wa = await _context.wallet.FindAsync(Id);
            if (wa == null)
                return BadRequest("not thing.");

            _context.wallet.Remove(wa);
            await _context.SaveChangesAsync();

            return Ok(await _context.wallet.ToListAsync());
        }
    }
}
