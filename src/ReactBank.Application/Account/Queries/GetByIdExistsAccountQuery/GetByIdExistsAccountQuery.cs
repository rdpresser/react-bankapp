using MediatR;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Account.Queries.GetByIdExistsAccountQuery
{
    public record GetByIdExistsAccountQuery(Guid Id) : IRequest<Result<bool>>;
}
