using ReactBank.Domain.Interfaces.Repositores.Base;
using ReactBank.Domain.Models;

namespace ReactBank.Domain.Interfaces.Repositores
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        Task<Transaction> GetByTransactionTypeAsync(string transactionType);
        Task<Transaction> GetByDateTimeAsync(DateTime dateTime);
        Task<Transaction> GetBySourceAccountIdAsync(Guid sourceAccountId);
        Task<Transaction> GetByDestinationAccountIdAsync(Guid destinationAccountId);
    }
}
