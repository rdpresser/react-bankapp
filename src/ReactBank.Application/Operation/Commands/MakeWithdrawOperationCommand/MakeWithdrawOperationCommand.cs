using MediatR;
using ReactBank.Application.Operation.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Operation.Commands.MakeWithdrawOperationCommand
{
    /// <summary>
    /// Make a withdrawal operation
    /// </summary>
    /// <param name="AccountId"></param>
    /// <param name="Amount"></param>
    public record MakeWithdrawOperationCommand(
        Guid AccountId,
        decimal Amount
    ) : IRequest<Result<DefaultOperationDataResponse>>;
}
