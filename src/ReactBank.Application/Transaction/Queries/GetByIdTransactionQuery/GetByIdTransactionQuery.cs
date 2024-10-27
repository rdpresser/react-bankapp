using MediatR;
using ReactBank.Application.Transaction.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Transaction.Queries.GetByIdTransactionQuery
{
    public record GetByIdTransactionQuery(Guid Id) : IRequest<Result<TransactionDataResponse>>;
}
