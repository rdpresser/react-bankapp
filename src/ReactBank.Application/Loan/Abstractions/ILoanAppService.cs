using ReactBank.Application.Loan.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Loan.Abstractions
{
    public interface ILoanAppService
    {
        Task<Result<LoanDataResponse>> GetByIdAsync(Guid id);
        Task<Result<IEnumerable<LoanDataResponse>>> GetAllAsync();
    }
}
