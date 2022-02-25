using TodoApi.Models;

namespace TodoApi.IRepository
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetPayments();
        Task<Payment> GetPayment(int id);
        Task<int> InsertPayment(Payment payment);
        Task<bool> UpdatePayment(Payment payment);
        Task<bool> DeletePayment(int id);
    }
}
