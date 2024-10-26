using MediatR;
using ReactBank.Application.Customer.Abstractions;
using ReactBank.Application.Customer.Commands.CreateCustomerCommand;
using ReactBank.Application.Customer.DataContracts;
using ReactBank.Application.Customer.Queries.GetAllCustomerQuery;
using ReactBank.Application.Customer.Queries.GetByIdCustomerQuery;
using ReactBank.Application.Customer.Queries.GetByIdExistsCustomerQuery;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMediator _mediator;

        public CustomerAppService(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator), $"{nameof(mediator)} could not be null");
        }

        public async Task<Result<CustomerDataResponse>> CreateCustomerAsync(CustomerDataRequest customerDataRequest)
        {
            return await _mediator.Send(MapDataRequestToCommand(customerDataRequest));
        }

        public async Task<Result<bool>> Exists(Guid id)
        {
            return await _mediator.Send(new GetByIdExistsCustomerQuery(id));
        }

        public async Task<Result<IEnumerable<CustomerDataResponse>>> GetAllAsync()
        {
            return await _mediator.Send(new GetAllCustomerQuery());
        }

        public async Task<Result<CustomerDataResponse>> GetByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetByIdCustomerQuery(id));
        }

        public CreateCustomerCommand MapDataRequestToCommand(CustomerDataRequest customerDataRequest)
        {
            return new CreateCustomerCommand(
                customerDataRequest.Name,
                customerDataRequest.Email,
                customerDataRequest.Phone,
                customerDataRequest.StreetAddress,
                customerDataRequest.City,
                customerDataRequest.State,
                customerDataRequest.ZipCode,
                customerDataRequest.DateOfBirth,
                customerDataRequest.IdentityDocument
            );
        }
    }
}
