using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly DataContext _context;

        public PaymentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Payment>>> Get()
        {
            return Ok(await _context.payment.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Payment>>> Get(int Id)
        {
            var pm = await _context.payment.FindAsync(Id);
            if (pm == null)
                return BadRequest("not thing.");
            return Ok(pm);
        }

        [HttpPost]
        public async Task<ActionResult<List<Payment>>> Add(Payment pm)
        {
            _context.payment.Add(pm);
            await _context.SaveChangesAsync();

            return Ok(await _context.payment.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Payment>>> Update(Payment request)
        {
            var pm = await _context.payment.FindAsync(request.Id);
            if (pm == null)
                return BadRequest("not thing.");

            pm.Id = request.Id;
            pm.Date = request.Date;
            pm.Type = request.Type;
            pm.Money = request.Money;
            pm.TripId = request.TripId;
            pm.TransactionId = request.TransactionId;
            pm.PaymentCode = request.PaymentCode;
            
            await _context.SaveChangesAsync();

            return Ok(await _context.payment.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Payment>>> Delete(int Id)
        {
            var pm = await _context.payment.FindAsync(Id);
            if (pm == null)
                return BadRequest("not thing.");

            _context.payment.Remove(pm);
            await _context.SaveChangesAsync();

            return Ok(await _context.payment.ToListAsync());
        }
    }
}
