using ReactBank.Application.DataContracts;

namespace ReactBank.Application.Interfaces
{
    public interface IOperationAppService : IDisposable
    {
        Task MakeDeposit(MakeDepositOperationDataRequest makeDepositOperationDataRequest);
        //void MakeWithdrawal(Guid accountId, decimal amount);
        //void MakeTransfer(Guid sourceAccountId, Guid destinationAccountId, decimal amount);
        //void ContractLoan(Guid accountId, decimal amount);
    }
}
