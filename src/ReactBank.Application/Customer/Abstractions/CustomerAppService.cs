using MediatR;
using ReactBank.Application.Customer.Abstractions;
using ReactBank.Application.Customer.Commands.CreateCustomerCommand;
using ReactBank.Application.Customer.DataContracts;
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

        public async Task<Result<CustomerDataResponse>> GetByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetByIdCustomerQuery(id));
        }

        public CreateCustomerCommand MapDataRequestToCommand(CustomerDataRequest accountDataRequest)
        {
            return new CreateCustomerCommand(
                accountDataRequest.Name,
                accountDataRequest.Email,
                accountDataRequest.Phone,
                accountDataRequest.StreetAddress,
                accountDataRequest.City,
                accountDataRequest.State,
                accountDataRequest.ZipCode,
                accountDataRequest.DateOfBirth,
                accountDataRequest.IdentityDocument
            );
        }

        //public override async Task<IEnumerable<CustomerDataResponse>> GetAllAsync()
        //{
        //    var list = await BaseService.GetAllNoTracking()
        //        .OrderBy(x => x.Name)
        //        .ToListAsync();
        //    return list.Select(x => MapDomainEntityToDataResponse(x));
        //}

        //public override Customer MapDataRequestToDomainEntity(CustomerDataRequest dataContract)
        //{
        //    return new Customer
        //    {
        //        Email = dataContract.Email,
        //        IdentityDocument = dataContract.IdentityDocument,
        //        Phone = dataContract.Phone,
        //        State = dataContract.State,
        //        ZipCode = dataContract.ZipCode,
        //        City = dataContract.City,
        //        DateOfBirth = dataContract.DateOfBirth,
        //        Name = dataContract.Name,
        //        StreetAddress = dataContract.StreetAddress
        //    };
        //}

        //public override CustomerDataResponse MapDomainEntityToDataResponse(Customer domainEntity)
        //{
        //    return new CustomerDataResponse
        //    {
        //        Email = domainEntity.Email,
        //        IdentityDocument = domainEntity.IdentityDocument,
        //        Phone = domainEntity.Phone,
        //        State = domainEntity.State,
        //        ZipCode = domainEntity.ZipCode,
        //        City = domainEntity.City,
        //        DateOfBirth = domainEntity.DateOfBirth.ToString("MMMM dd, yyyy"),
        //        Name = domainEntity.Name,
        //        StreetAddress = domainEntity.StreetAddress,
        //        Id = domainEntity.Id
        //    };
        //}
    }
}
