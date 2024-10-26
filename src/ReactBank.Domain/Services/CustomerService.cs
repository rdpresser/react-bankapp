using Microsoft.EntityFrameworkCore;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services;
using ReactBank.Domain.Models;
using ReactBank.Domain.Services.Base;

namespace ReactBank.Domain.Services
{
    public class CustomerService(ICustomerRepository customerRepository) : BaseService<Customer>(customerRepository), ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllNoTracking()
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}
