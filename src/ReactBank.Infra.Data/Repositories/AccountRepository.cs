using Microsoft.EntityFrameworkCore;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Models;
using ReactBank.Infra.Data.Context;
using ReactBank.Infra.Data.Repositories.Base;

namespace ReactBank.Infra.Data.Repositories
{
    public class AccountRepository(ApplicationDbContext applicationDbContext) : BaseRepository<Account>(applicationDbContext), IAccountRepository
    {
        public async Task<bool> ExistsAccountNumberAsync(string accountNumber)
        {
            return await DbSet.AnyAsync(e => e.AccountNumber == accountNumber);
        }

        public Task<Account> GetByAccountNumberAsync(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetByAccountTypeAsync(string accountType)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetByCustomerIdAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
