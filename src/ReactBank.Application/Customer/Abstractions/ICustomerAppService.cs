using ReactBank.Application.Commons.Bases.Interfaces.Services;
using ReactBank.Application.Customer.DataContracts;

namespace ReactBank.Application.Customer.Abstractions
{
    public interface ICustomerAppService : IBaseAppService<CustomerDataRequest, CustomerDataResponse>
    {

    }
}
