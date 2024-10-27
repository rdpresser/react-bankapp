using MediatR;
using ReactBank.Application.Loan.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Loan.Commands.CreateLoanCommand
{
    /// <summary>
    /// Create a new loan
    /// </summary>
    /// <param name="Amount"></param>
    /// <param name="InterestRate"></param>
    /// <param name="StartDate"></param>
    /// <param name="EndDate"></param>
    /// <param name="AccountId"></param>
    public record CreateLoanCommand(
       decimal Amount,
       decimal InterestRate,
       DateTime StartDate,
       DateTime EndDate,
       Guid AccountId
    ) : IRequest<Result<LoanDataResponse>>;
}
