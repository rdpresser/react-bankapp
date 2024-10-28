using ReactBank.Application.Loan.DataContracts;
using ReactBank.Application.Operation.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Operation.Abstractions
{
    public interface IOperationAppService
    {
        Task<Result<DefaultOperationDataResponse>> MakeDeposit(MakeDepositOperationDataRequest makeDepositOperationDataRequest);
        Task<Result<DefaultOperationDataResponse>> MakeWithdrawal(MakeWithdrawOperationDataRequest makeWithdrawOperationDataRequest);
        Task<Result<DefaultOperationDataResponse>> MakeTransfer(MakeTransferOperationDataRequest makeTransferOperationDataRequest);
        Task<Result<LoanDataResponse>> TakeLoan(TakeLoanOperationDataRequest takeLoanOperationDataRequest);
    }
}
