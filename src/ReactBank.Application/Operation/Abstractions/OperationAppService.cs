using MediatR;
using ReactBank.Application.Operation.Commands.MakeDepositOperationCommand;
using ReactBank.Application.Operation.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Operation.Abstractions
{
    public class OperationAppService : IOperationAppService
    {
        private readonly IMediator _mediator;

        public OperationAppService(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator), $"{nameof(mediator)} could not be null");
        }

        public async Task<Result<Guid>> MakeDeposit(MakeDepositOperationDataRequest makeDepositOperationDataRequest)
        {
            var command = new MakeDepositOperationCommand(
                makeDepositOperationDataRequest.AccountId,
                makeDepositOperationDataRequest.Amount
            );

            return await _mediator.Send(command);
        }

        public async Task MakeTransfer(MakeTransferOperationDataRequest makeTransferOperationDataRequest)
        {
            (Guid sourceAccountId, Guid destinationAccountId, decimal amount) =
                (makeTransferOperationDataRequest.SourceAccountId, makeTransferOperationDataRequest.DestinationAccountId, makeTransferOperationDataRequest.Amount);

        }

        public async Task MakeWithdrawal(MakeWithdrawOperationDataRequest makeWithdrawOperationDataRequest)
        {
            (Guid accountId, decimal amount) = (makeWithdrawOperationDataRequest.AccountId, makeWithdrawOperationDataRequest.Amount);

        }

        public async Task TakeLoan(TakeLoanOperationDataRequest takeLoanOperationDataRequest)
        {
            (Guid accountId, decimal amount, DateTime startDate, DateTime endDate, decimal interestRate) =
                (takeLoanOperationDataRequest.AccountId, takeLoanOperationDataRequest.Amount,
                takeLoanOperationDataRequest.StartDate, takeLoanOperationDataRequest.EndDate, takeLoanOperationDataRequest.InterestRate);
        }
    }
}
