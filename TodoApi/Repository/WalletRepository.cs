using Microsoft.EntityFrameworkCore;
using TodoApi.IRepository;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly TnGContext _context;
        public WalletRepository (TnGContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteWallet(int id)
        {
            var w = await _context.Wallets.FindAsync(id);
            _context.Wallets.Remove(w);
            return true;
        }

        public async Task<Wallet> GetWallet(int id)
        {
            var w = await _context.Wallets.FindAsync(id);
            return w;
        }

        public async Task<IEnumerable<Wallet>> GetWallets()
        {
            var ws = await _context.Wallets.ToListAsync();
            return ws;
        }

        public async Task<int> InsertWallet(Wallet wallet)
        {
            await _context.Wallets.AddAsync(wallet);
            await _context.SaveChangesAsync();
            return wallet.Id;
        }

        public async Task<bool> UpdateWallet(Wallet wallet)
        {
            _context.Wallets.Update(wallet);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
