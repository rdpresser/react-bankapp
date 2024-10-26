using MediatR;
using ReactBank.Application.Customer.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Customer.Queries.GetByIdCustomerQuery
{
    public record GetByIdCustomerQuery(Guid Id) : IRequest<Result<CustomerDataResponse>>;
}
