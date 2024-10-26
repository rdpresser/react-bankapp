using MediatR;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Customer.Queries.GetByIdExistsCustomerQuery
{
    public record GetByIdExistsCustomerQuery(Guid Id) : IRequest<Result<bool>>;
}
