using TodoApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApi.IRepository
{
    public interface IWalletRepository
    {
        Task<IEnumerable<Wallet>> GetWallets();
        Task<Wallet> GetWallet(int id);
        Task<int> InsertWallet(Wallet wallet);
        Task<bool> UpdateWallet(Wallet wallet);
        Task<bool> DeleteWallet(int id);
    }
}
