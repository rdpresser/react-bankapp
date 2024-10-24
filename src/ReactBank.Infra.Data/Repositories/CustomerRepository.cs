using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Models;
using ReactBank.Infra.Data.Context;
using ReactBank.Infra.Data.Repositories.Base;

namespace ReactBank.Infra.Data.Repositories
{
    public class CustomerRepository(ApplicationDbContext applicationDbContext) : BaseRepository<Customer>(applicationDbContext), ICustomerRepository
    {
        public Task<Customer> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByIdentityDocumentAsync(string identityDocument)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
