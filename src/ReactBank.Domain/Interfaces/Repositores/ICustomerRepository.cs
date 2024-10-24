using ReactBank.Domain.Interfaces.Repositores.Base;
using ReactBank.Domain.Models;

namespace ReactBank.Domain.Interfaces.Repositores
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<Customer> GetByNameAsync(string name);
        Task<Customer> GetByEmailAsync(string email);
        Task<Customer> GetByIdentityDocumentAsync(string identityDocument);
    }
}
