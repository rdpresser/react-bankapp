using Microsoft.EntityFrameworkCore;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services;
using ReactBank.Domain.Models;
using ReactBank.Domain.Services.Base;

namespace ReactBank.Domain.Services
{
    public class AccountService(IAccountRepository baseRepository) : BaseService<Account>(baseRepository), IAccountService
    {
        private readonly IAccountRepository _accountRepository = baseRepository;

        public async Task<bool> ExistsAccountNumberAsync(string accountNumber)
        {
            return await _accountRepository.ExistsAccountNumberAsync(accountNumber);
        }

        public async Task<Account> GetByAccountNumberAsync(string accountNumber)
        {
            return await _accountRepository.GetByAccountNumberAsync(accountNumber);
        }

        public async Task<Account> GetByCustomerIdAsync(Guid customerId)
        {
            return await _accountRepository.GetByCustomerIdAsync(customerId);
        }

        public async Task<Account> GetByAccountTypeAsync(string accountType)
        {
            return await _accountRepository.GetByAccountTypeAsync(accountType);
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _accountRepository.GetAllNoTracking()
                .OrderBy(x => x.AccountNumber)
                .ToListAsync();
        }
    }
}
