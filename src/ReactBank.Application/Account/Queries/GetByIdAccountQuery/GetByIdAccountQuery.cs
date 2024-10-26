using MediatR;
using ReactBank.Application.Account.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Account.Queries.GetByIdAccountQuery
{
    public record GetByIdAccountQuery(Guid Id) : IRequest<Result<AccountDataResponse>>;
}
