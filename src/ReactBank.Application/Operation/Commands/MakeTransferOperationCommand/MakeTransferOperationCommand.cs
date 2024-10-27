using MediatR;
using ReactBank.Application.Operation.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Operation.Commands.MakeTransferOperationCommand
{
    /// <summary>
    /// Make a transfer operation
    /// </summary>
    /// <param name="SourceAccountId"></param>
    /// <param name="DestinationAccountId"></param>
    /// <param name="Amount"></param>
    public record MakeTransferOperationCommand(
        Guid SourceAccountId,
        Guid DestinationAccountId,
        decimal Amount
    ) : IRequest<Result<DefaultOperationDataResponse>>;
}
