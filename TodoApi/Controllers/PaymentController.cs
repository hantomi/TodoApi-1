using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.IRepository;
using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.Controllers
{
    [Route("api/v1/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly TnGContext _context;
        private IPaymentRepository paymentRepo;
        public PaymentController(TnGContext context)
        {
            this.paymentRepo = new PaymentRepository(context);
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Payment>>> Get()
        {
            return Ok(await _context.Payments.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Payment>>> Get(int Id)
        {
            var pm = await _context.Payments.FindAsync(Id);
            if (pm == null)
                return BadRequest("not thing.");
            return Ok(pm);
        }

        [HttpPost]
        public async Task<ActionResult<List<Payment>>> Add(Payment pm)
        {
            _context.Payments.Add(pm);
            await _context.SaveChangesAsync();

            return Ok(await _context.Payments.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Payment>>> Update(Payment request)
        {
            var pm = await _context.Payments.FindAsync(request.Id);
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

            return Ok(await _context.Payments.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Payment>>> Delete(int Id)
        {
            var pm = await _context.Payments.FindAsync(Id);
            if (pm == null)
                return BadRequest("not thing.");

            _context.Payments.Remove(pm);
            await _context.SaveChangesAsync();

            return Ok(await _context.Payments.ToListAsync());
        }
    }
}
