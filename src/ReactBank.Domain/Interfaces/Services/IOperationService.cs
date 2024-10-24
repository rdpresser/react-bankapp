namespace ReactBank.Domain.Interfaces.Services
{
    public interface IOperationService
    {
        Task MakeDeposit(Guid accountId, decimal amount);
        void MakeWithdrawal(Guid accountId, decimal amount);
        void MakeTransfer(Guid sourceAccountId, Guid destinationAccountId, decimal amount);
        void ContractLoan(Guid accountId, decimal amount);
    }
}
