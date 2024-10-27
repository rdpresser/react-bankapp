using MediatR;
using ReactBank.Application.Operation.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Operation.Commands.MakeDepositOperationCommand
{
    /// <summary>
    /// Make a deposit operation
    /// </summary>
    /// <param name="AccountId"></param>
    /// <param name="Amount"></param>
    public record MakeDepositOperationCommand(
        Guid AccountId,
        decimal Amount
    ) : IRequest<Result<DefaultOperationDataResponse>>;
}
