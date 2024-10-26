using MediatR;
using ReactBank.Application.Account.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Account.Queries.GetAllAccountQuery
{
    public record GetAllAccountQuery() : IRequest<Result<IEnumerable<AccountDataResponse>>>;
}
