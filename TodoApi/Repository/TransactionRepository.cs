using Microsoft.EntityFrameworkCore;
using TodoApi.IRepository;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TnGContext _context;
        public TransactionRepository (TnGContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteTransaction(int id)
        {
            var t = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(t);
            return true;
        }

        public async Task<Transaction> GetTransaction(int id)
        {
            var t = await _context.Transactions.FindAsync(id);
            return t;
        }

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            var ts = await _context.Transactions.ToListAsync();
            return ts;
        }

        public async Task<int> InsertTransaction(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction.Id;
        }

        public async Task<bool> UpdateTransaction(Transaction transaction)
        {
            _context.Transactions.Remove(transaction);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
