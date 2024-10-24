using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Models;
using ReactBank.Infra.Data.Context;
using ReactBank.Infra.Data.Repositories.Base;

namespace ReactBank.Infra.Data.Repositories
{
    public class TransactionRepository(ApplicationDbContext applicationDbContext) : BaseRepository<Transaction>(applicationDbContext), ITransactionRepository
    {
        public Task<Transaction> GetByDateTimeAsync(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetByDestinationAccountIdAsync(Guid destinationAccountId)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetBySourceAccountIdAsync(Guid sourceAccountId)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetByTransactionTypeAsync(string transactionType)
        {
            throw new NotImplementedException();
        }
    }
}
