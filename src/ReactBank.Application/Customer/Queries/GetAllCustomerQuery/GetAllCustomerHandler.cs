using MediatR;
using ReactBank.Application.Customer.DataContracts;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Customer.Queries.GetAllCustomerQuery
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, Result<IEnumerable<CustomerDataResponse>>>
    {
        private readonly ICustomerService _customerService;

        public GetAllCustomerHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<Result<IEnumerable<CustomerDataResponse>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var customers = await _customerService.GetAllAsync();
                if (customers != null)
                {
                    return Result<IEnumerable<CustomerDataResponse>>.Success(customers.Select(customer => new CustomerDataResponse(
                        Id: customer.Id,
                        Name: customer.Name,
                        Email: customer.Email,
                        Phone: customer.Phone,
                        StreetAddress: customer.StreetAddress,
                        City: customer.City,
                        State: customer.State,
                        ZipCode: customer.ZipCode,
                        DateOfBirth: customer.DateOfBirth.ToString("yyyy-MM-dd"),
                        IdentityDocument: customer.IdentityDocument
                    )));
                }

                return Result<IEnumerable<CustomerDataResponse>>.NotFound(new Dictionary<string, string[]> { { "GetAllCustomerQuery", ["No customers found"] } });
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<CustomerDataResponse>>.Failure(new Dictionary<string, string[]> { { "GetAllCustomerQuery", [ex.Message] } });
            }
        }
    }
}
