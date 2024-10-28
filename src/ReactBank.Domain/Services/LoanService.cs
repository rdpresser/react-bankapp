using Microsoft.EntityFrameworkCore;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services;
using ReactBank.Domain.Models;
using ReactBank.Domain.Services.Base;

namespace ReactBank.Domain.Services
{
    public class LoanService(ILoanRepository loanRepository) : BaseService<Loan>(loanRepository), ILoanService
    {
        public async Task<IEnumerable<Loan>> GetAllAsync()
        {
            return await loanRepository.GetAllNoTracking()
                .OrderBy(x => x.StartDate)
                .ToListAsync();
        }
    }
}
