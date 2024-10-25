namespace ReactBank.Domain.Interfaces.Services
{
    public interface IOperationService
    {
        Task MakeDeposit(Guid accountId, decimal amount);
        Task MakeWithdrawal(Guid accountId, decimal amount);
        Task MakeTransfer(Guid sourceAccountId, Guid destinationAccountId, decimal amount);
        Task TakeLoan(Guid accountId, decimal amount, DateTime startDate, DateTime endDate, decimal interestRate);
    }
}
