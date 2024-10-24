using ReactBank.Domain.Interfaces.Services;
using ReactBank.Domain.Models;

namespace ReactBank.Domain.Services
{
    public class OperationService : IOperationService
    {
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;

        public OperationService(IAccountService accountService, ITransactionService transactionService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService), $"{nameof(accountService)} could not be null");
            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService), $"{nameof(transactionService)} could not be null");
        }

        public void ContractLoan(Guid accountId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public async Task MakeDeposit(Guid accountId, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.", nameof(amount));
            }

            var account = await _accountService.GetByIdAsync(accountId);
            if (account == null)
            {
                throw new InvalidOperationException("Account not found.");
            }

            account.Balance += amount;

            var transaction = new Transaction
            {
                TransactionType = "Deposit",
                Amount = amount,
                Currency = account.Currency,
                DateTime = DateTime.UtcNow,
                SourceAccountId = accountId,
                DestinationAccountId = accountId
            };

            await _transactionService.AddAsync(transaction);
            await _accountService.UpdateAsync(account);
        }

        public void MakeTransfer(Guid sourceAccountId, Guid destinationAccountId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public void MakeWithdrawal(Guid accountId, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
