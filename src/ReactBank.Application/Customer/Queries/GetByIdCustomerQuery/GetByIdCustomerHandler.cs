using MediatR;
using ReactBank.Application.Customer.DataContracts;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Customer.Queries.GetByIdCustomerQuery
{
    public class GetByIdCustomerHandler : IRequestHandler<GetByIdCustomerQuery, Result<CustomerDataResponse>>
    {
        private readonly ICustomerService _customerService;

        public GetByIdCustomerHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<Result<CustomerDataResponse>> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _customerService.GetByIdAsync(request.Id);
                if (customer == null)
                {
                    return Result<CustomerDataResponse>.NotFound(new Dictionary<string, string[]> { { "GetByIdCustomerQuery", ["Customer not found"] } });
                }

                return Result<CustomerDataResponse>.Success(new CustomerDataResponse(
                    Id: customer.Id,
                    Name: customer.Name,
                    Email: customer.Email,
                    Phone: customer.Phone,
                    StreetAddress: customer.StreetAddress,
                    City: customer.City,
                    State: customer.State,
                    ZipCode: customer.ZipCode,
                    DateOfBirth: customer.DateOfBirth.ToString("MMMM dd, yyyy"),
                    IdentityDocument: customer.IdentityDocument
                ));
            }
            catch (Exception ex)
            {
                return Result<CustomerDataResponse>.Failure(new Dictionary<string, string[]> { { "GetByIdCustomerQuery", [ex.Message] } });
            }
        }
    }
}
