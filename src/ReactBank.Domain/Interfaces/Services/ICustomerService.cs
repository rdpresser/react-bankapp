using ReactBank.Domain.Interfaces.Services.Base;
using ReactBank.Domain.Models;

namespace ReactBank.Domain.Interfaces.Services
{
    public interface ICustomerService : IBaseService<Customer>
    {
        Task<IEnumerable<Customer>> GetAllAsync();
    }
}
