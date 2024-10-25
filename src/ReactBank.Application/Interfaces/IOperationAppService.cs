using ReactBank.Application.DataContracts;

namespace ReactBank.Application.Interfaces
{
    public interface IOperationAppService
    {
        Task MakeDeposit(MakeDepositOperationDataRequest makeDepositOperationDataRequest);
        Task MakeWithdrawal(MakeWithdrawOperationDataRequest makeWithdrawOperationDataRequest);
        Task MakeTransfer(MakeTransferOperationDataRequest makeTransferOperationDataRequest);
        Task TakeLoan(TakeLoanOperationDataRequest takeLoanOperationDataRequest);
    }
}
