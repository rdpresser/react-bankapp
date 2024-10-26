using ReactBank.Application.Customer.Commands.CreateCustomerCommand;
using ReactBank.Application.Customer.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Customer.Abstractions
{
    public interface ICustomerAppService
    {
        CreateCustomerCommand MapDataRequestToCommand(CustomerDataRequest customerDataRequest);
        Task<Result<CustomerDataResponse>> CreateCustomerAsync(CustomerDataRequest customerDataRequest);
        Task<Result<bool>> Exists(Guid id);
        Task<Result<CustomerDataResponse>> GetByIdAsync(Guid id);
    }
}
