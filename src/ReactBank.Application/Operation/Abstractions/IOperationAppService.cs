using ReactBank.Application.Operation.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Operation.Abstractions
{
    public interface IOperationAppService
    {
        Task<Result<Guid>> MakeDeposit(MakeDepositOperationDataRequest makeDepositOperationDataRequest);
        Task MakeWithdrawal(MakeWithdrawOperationDataRequest makeWithdrawOperationDataRequest);
        Task MakeTransfer(MakeTransferOperationDataRequest makeTransferOperationDataRequest);
        Task TakeLoan(TakeLoanOperationDataRequest takeLoanOperationDataRequest);
    }
}
