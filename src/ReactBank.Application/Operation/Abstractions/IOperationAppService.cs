using ReactBank.Application.Operation.DataContracts;

namespace ReactBank.Application.Operation.Abstractions
{
    public interface IOperationAppService
    {
        Task MakeDeposit(MakeDepositOperationDataRequest makeDepositOperationDataRequest);
        Task MakeWithdrawal(MakeWithdrawOperationDataRequest makeWithdrawOperationDataRequest);
        Task MakeTransfer(MakeTransferOperationDataRequest makeTransferOperationDataRequest);
        Task TakeLoan(TakeLoanOperationDataRequest takeLoanOperationDataRequest);
    }
}
