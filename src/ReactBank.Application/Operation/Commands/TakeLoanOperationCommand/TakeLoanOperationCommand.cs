using MediatR;
using ReactBank.Application.Loan.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Operation.Commands.TakeLoanOperationCommand
{
    /// <summary>
    /// Take a loan operation
    /// </summary>
    /// <param name="AccountId"></param>
    /// <param name="Amount"></param>
    /// <param name="InterestRate"></param>
    /// <param name="StartDate"></param>
    /// <param name="EndDate"></param>
    public record TakeLoanOperationCommand(
        Guid AccountId,
        decimal Amount,
        decimal InterestRate,
        DateTime StartDate,
        DateTime EndDate
    ) : IRequest<Result<LoanDataResponse>>;
}
