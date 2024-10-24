using Microsoft.EntityFrameworkCore;
using ReactBank.Application.DataContracts;
using ReactBank.Application.Interfaces;
using ReactBank.Application.Services.Base;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services;
using ReactBank.Domain.Models;

namespace ReactBank.Application.Services
{
    public class CustomerAppService : BaseAppDataContractDomainService<CustomerDataRequest, CustomerDataResponse, Customer>, ICustomerAppService
    {
        private readonly ICustomerService _customerService;

        public CustomerAppService(IUnitOfWork unitOfWork, ICustomerService customerService)
            : base(unitOfWork, customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService), $"{nameof(customerService)} could not be null");
        }

        public override async Task<IEnumerable<CustomerDataResponse>> GetAllAsync()
        {
            var list = await BaseService.GetAllNoTracking().ToListAsync();

            return list.Select(x => new CustomerDataResponse
            {
                Email = x.Email,
                IdentityDocument = x.IdentityDocument,
                Phone = x.Phone,
                State = x.State,
                ZipCode = x.ZipCode,
                City = x.City,
                DateOfBirth = x.DateOfBirth,
                Name = x.Name,
                StreetAddress = x.StreetAddress,
                Id = x.Id
            });
        }

        public override Customer MapDataRequestToDomainEntity(CustomerDataRequest dataContract)
        {
            return new Customer
            {
                Email = dataContract.Email,
                IdentityDocument = dataContract.IdentityDocument,
                Phone = dataContract.Phone,
                State = dataContract.State,
                ZipCode = dataContract.ZipCode,
                City = dataContract.City,
                DateOfBirth = dataContract.DateOfBirth,
                Name = dataContract.Name,
                StreetAddress = dataContract.StreetAddress
            };
        }

        public override CustomerDataResponse MapDomainEntityToDataResponse(Customer domainEntity)
        {
            return new CustomerDataResponse
            {
                Email = domainEntity.Email,
                IdentityDocument = domainEntity.IdentityDocument,
                Phone = domainEntity.Phone,
                State = domainEntity.State,
                ZipCode = domainEntity.ZipCode,
                City = domainEntity.City,
                DateOfBirth = domainEntity.DateOfBirth,
                Name = domainEntity.Name,
                StreetAddress = domainEntity.StreetAddress,
                Id = domainEntity.Id
            };
        }
    }
}
