using Microsoft.EntityFrameworkCore;
using TodoApi.IRepository;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class DepositRepository : IDepositRepository
    {
        private readonly TnGContext _context;
        public DepositRepository (TnGContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteDeposit(int id)
        {
            var d = await _context.Deposits.FindAsync(id);
            _context.Deposits.Remove(d);
            return true;
        }

        public async Task<Deposit> GetDeposit(int id)
        {
            var d = await _context.Deposits.FindAsync(id);
            return d;
        }

        public async Task<IEnumerable<Deposit>> GetDeposits()
        {
            var ds = await _context.Deposits.ToListAsync();
            return ds;
        }

        public async Task<int> InsertDepsoit(Deposit deposit)
        {
            await _context.Deposits.AddAsync(deposit);
            await _context.SaveChangesAsync();
            return deposit.Id;
        }

        public async Task<bool> UpdateDeposit(Deposit deposit)
        {
            _context.Deposits.Update(deposit);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
