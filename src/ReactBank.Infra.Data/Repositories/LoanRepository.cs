using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Models;
using ReactBank.Infra.Data.Context;
using ReactBank.Infra.Data.Repositories.Base;

namespace ReactBank.Infra.Data.Repositories
{
    public class LoanRepository(ApplicationDbContext applicationDbContext) : BaseRepository<Loan>(applicationDbContext), ILoanRepository
    {
        public Task<Loan> GetByAccountIdAsync(Guid accountId)
        {
            throw new NotImplementedException();
        }

        public Task<Loan> GetByEndDateAsync(DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<Loan> GetByStartDateAsync(DateTime startDate)
        {
            throw new NotImplementedException();
        }
    }
}
