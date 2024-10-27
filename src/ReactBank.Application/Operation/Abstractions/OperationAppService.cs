using MediatR;
using ReactBank.Application.Operation.Commands.MakeDepositOperationCommand;
using ReactBank.Application.Operation.Commands.MakeTransferOperationCommand;
using ReactBank.Application.Operation.Commands.MakeWithdrawOperationCommand;
using ReactBank.Application.Operation.Commands.TakeLoanOperationCommand;
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

        public async Task<Result<DefaultOperationDataResponse>> MakeDeposit(MakeDepositOperationDataRequest makeDepositOperationDataRequest)
        {
            var command = new MakeDepositOperationCommand(
                makeDepositOperationDataRequest.AccountId,
                makeDepositOperationDataRequest.Amount
            );

            return await _mediator.Send(command);
        }

        public async Task<Result<DefaultOperationDataResponse>> MakeTransfer(MakeTransferOperationDataRequest makeTransferOperationDataRequest)
        {
            var command = new MakeTransferOperationCommand(
                makeTransferOperationDataRequest.SourceAccountId,
                makeTransferOperationDataRequest.DestinationAccountId,
                makeTransferOperationDataRequest.Amount
            );

            return await _mediator.Send(command);
        }

        public async Task<Result<DefaultOperationDataResponse>> MakeWithdrawal(MakeWithdrawOperationDataRequest makeWithdrawOperationDataRequest)
        {
            var command = new MakeWithdrawOperationCommand(
                makeWithdrawOperationDataRequest.AccountId,
                makeWithdrawOperationDataRequest.Amount
            );

            return await _mediator.Send(command);
        }

        public async Task<Result<DefaultOperationDataResponse>> TakeLoan(TakeLoanOperationDataRequest takeLoanOperationDataRequest)
        {
            var command = new TakeLoanOperationCommand(
                takeLoanOperationDataRequest.AccountId,
                takeLoanOperationDataRequest.Amount,
                takeLoanOperationDataRequest.InterestRate,
                takeLoanOperationDataRequest.StartDate,
                takeLoanOperationDataRequest.EndDate
            );

            return await _mediator.Send(command);
        }
    }
}
