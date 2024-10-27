using ReactBank.Application.Loan.Commands.CreateLoanCommand;
using ReactBank.Application.Loan.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Loan.Abstractions
{
    public interface ILoanAppService
    {
        CreateLoanCommand MapDataRequestToCommand(LoanDataRequest loanDataRequest);
        Task<Result<LoanDataResponse>> CreateLoanAsync(LoanDataRequest loanDataRequest);
        Task<Result<LoanDataResponse>> GetByIdAsync(Guid id);
        Task<Result<IEnumerable<LoanDataResponse>>> GetAllAsync();
    }
}
