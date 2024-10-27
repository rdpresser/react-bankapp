using MediatR;
using ReactBank.Application.Transaction.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Transaction.Queries.GetAllTransactionQuery
{
    public record GetAllTransactionQuery() : IRequest<Result<IEnumerable<TransactionDataResponse>>>;
}
