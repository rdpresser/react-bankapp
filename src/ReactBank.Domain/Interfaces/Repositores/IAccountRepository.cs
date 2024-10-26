using ReactBank.Domain.Interfaces.Repositores.Base;
using ReactBank.Domain.Models;

namespace ReactBank.Domain.Interfaces.Repositores
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<Account> GetByAccountNumberAsync(string accountNumber);
        Task<bool> ExistsAccountNumberAsync(string accountNumber);
        Task<Account> GetByCustomerIdAsync(Guid customerId);
        Task<Account> GetByAccountTypeAsync(string accountType);
    }
}
