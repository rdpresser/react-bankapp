using ReactBank.Application.Commons.Bases.Interfaces.Services;
using ReactBank.Application.Transaction.DataContracts;

namespace ReactBank.Application.Transaction.Abstractions
{
    public interface ITransactionAppService : IBaseAppService<TransactionDataRequest, TransactionDataResponse>
    {

    }
}
