using MediatR;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Customer.Queries.GetByIdExistsCustomerQuery
{
    public class GetByIdExistsCustomerHandler : IRequestHandler<GetByIdExistsCustomerQuery, Result<bool>>
    {
        private readonly ICustomerService _customerService;

        public GetByIdExistsCustomerHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<Result<bool>> Handle(GetByIdExistsCustomerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var exists = await _customerService.Exists(request.Id);
                if (exists)
                {
                    return Result<bool>.Success(true);
                }
                return Result<bool>.Failure(new Dictionary<string, string> { { "GetByIdExistsCustomerQuery", "Customer not found" } });
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure(new Dictionary<string, string> { { "GetByIdExistsCustomerQuery", ex.Message } });
            }
        }
    }
}
