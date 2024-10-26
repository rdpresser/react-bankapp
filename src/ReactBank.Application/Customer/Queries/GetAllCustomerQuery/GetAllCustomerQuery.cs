using MediatR;
using ReactBank.Application.Customer.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Customer.Queries.GetAllCustomerQuery
{
    public record GetAllCustomerQuery() : IRequest<Result<IEnumerable<CustomerDataResponse>>>;
}
