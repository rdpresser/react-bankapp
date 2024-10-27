using ReactBank.Application.Transaction.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Transaction.Abstractions
{
    public interface ITransactionAppService
    {
        Task<Result<TransactionDataResponse>> GetByIdAsync(Guid id);
        Task<Result<IEnumerable<TransactionDataResponse>>> GetAllAsync();
    }
}
