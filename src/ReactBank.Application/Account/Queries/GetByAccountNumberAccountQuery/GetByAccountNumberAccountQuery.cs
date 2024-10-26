using MediatR;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Account.Queries.GetByAccountNumberAccountQuery
{
    public record GetByAccountNumberAccountQuery(string AccountNumber) : IRequest<Result<bool>>;
}
