using Microsoft.EntityFrameworkCore;
using TodoApi.IRepository;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly TnGContext _context;
        public PaymentRepository (TnGContext context)
        {
            _context = context;
        }
        public async Task<bool> DeletePayment(int id)
        {
            var p = await _context.Payments.FindAsync(id);
            _context.Payments.Remove(p);
            return true;
        }

        public async Task<Payment> GetPayment(int id)
        {
            var p = await _context.Payments.FindAsync(id);
            return p;
        }

        public async Task<IEnumerable<Payment>> GetPayments()
        {
            var ps = await _context.Payments.ToListAsync();
            return ps;
        }

        public async Task<int> InsertPayment(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment.Id;
        }

        public async Task<bool> UpdatePayment(Payment payment)
        {
            _context.Payments.Update(payment);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
