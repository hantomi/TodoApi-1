using TodoApi.Models;

namespace TodoApi.IRepository
{
    public interface IDepositRepository
    {
        Task<IEnumerable<Deposit>> GetDeposits();
        Task<Deposit> GetDeposit(int id);
        Task<int> InsertDepsoit(Deposit deposit);
        Task<bool> UpdateDeposit(Deposit deposit);
        Task<bool> DeleteDeposit(int id);
    }
}
