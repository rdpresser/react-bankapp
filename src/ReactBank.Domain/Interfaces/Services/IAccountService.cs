using ReactBank.Domain.Interfaces.Services.Base;
using ReactBank.Domain.Models;

namespace ReactBank.Domain.Interfaces.Services
{
    public interface IAccountService : IBaseService<Account>
    {
        Task<Account> GetByAccountNumberAsync(string accountNumber);
        Task<bool> ExistsAccountNumberAsync(string accountNumber);
        Task<Account> GetByCustomerIdAsync(Guid customerId);
        Task<Account> GetByAccountTypeAsync(string accountType);
        Task<IEnumerable<Account>> GetAllAsync();
    }
}
