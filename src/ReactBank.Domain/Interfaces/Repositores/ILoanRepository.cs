using ReactBank.Domain.Interfaces.Repositores.Base;
using ReactBank.Domain.Models;

namespace ReactBank.Domain.Interfaces.Repositores
{
    public interface ILoanRepository : IBaseRepository<Loan>
    {
        Task<Loan> GetByStartDateAsync(DateTime startDate);
        Task<Loan> GetByEndDateAsync(DateTime endDate);
        Task<Loan> GetByAccountIdAsync(Guid accountId);
    }
}
