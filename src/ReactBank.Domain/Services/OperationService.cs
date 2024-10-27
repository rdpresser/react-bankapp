using ReactBank.Domain.Interfaces.Services;
using ReactBank.Domain.Models;

namespace ReactBank.Domain.Services
{
    public class OperationService : IOperationService
    {
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;
        private readonly ILoanService _loanService;

        public OperationService(IAccountService accountService, ITransactionService transactionService, ILoanService loanService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService), $"{nameof(accountService)} could not be null");
            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService), $"{nameof(transactionService)} could not be null");
            _loanService = loanService ?? throw new ArgumentNullException(nameof(loanService), $"{nameof(loanService)} could not be null");
        }

        public async Task TakeLoan(Guid accountId, decimal amount, DateTime startDate, DateTime endDate, decimal interestRate)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Loan amount must be greater than zero.", nameof(amount));
            }

            var account = await _accountService.GetByIdAsync(accountId);
            if (account == null)
            {
                throw new InvalidOperationException("Account not found.");
            }

            account.Balance += amount;

            var transaction = new Transaction
            {
                TransactionType = "Loan",
                Amount = amount,
                Currency = account.Currency,
                DateTime = DateTime.UtcNow,
                SourceAccountId = accountId,
                DestinationAccountId = accountId
            };

            var loan = new Loan
            {
                Amount = amount,
                StartDate = startDate,
                EndDate = endDate,
                InterestRate = interestRate,
                AccountId = accountId
            };

            await _transactionService.AddAsync(transaction);
            await _accountService.UpdateAsync(account);
            await _loanService.AddAsync(loan);
        }

        //public async Task MakeDeposit(Guid accountId, decimal amount)
        //{
        //    if (amount <= 0)
        //    {
        //        throw new ArgumentException("Deposit amount must be greater than zero.", nameof(amount));
        //    }

        //    var account = await _accountService.GetByIdAsync(accountId);
        //    if (account == null)
        //    {
        //        throw new InvalidOperationException("Account not found.");
        //    }

        //    account.Balance += amount;

        //    var transaction = new Transaction
        //    {
        //        TransactionType = "Deposit",
        //        Amount = amount,
        //        Currency = account.Currency,
        //        DateTime = DateTime.UtcNow,
        //        SourceAccountId = accountId,
        //        DestinationAccountId = accountId
        //    };

        //    await _transactionService.AddAsync(transaction);
        //    await _accountService.UpdateAsync(account);
        //}

        public async Task MakeTransfer(Guid sourceAccountId, Guid destinationAccountId, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Transfer amount must be greater than zero.", nameof(amount));
            }

            if (sourceAccountId == destinationAccountId)
            {
                throw new ArgumentException("Source account ID and destination account ID shouldn't be the same.");
            }

            var sourceAccount = await _accountService.GetByIdAsync(sourceAccountId);
            if (sourceAccount == null)
            {
                throw new InvalidOperationException("Source account not found.");
            }

            var destinationAccount = await _accountService.GetByIdAsync(destinationAccountId);
            if (destinationAccount == null)
            {
                throw new InvalidOperationException("Destination account not found.");
            }

            if (sourceAccount.Balance < amount)
            {
                throw new InvalidOperationException("Insufficient funds in source account.");
            }

            sourceAccount.Balance -= amount;
            destinationAccount.Balance += amount;

            var transaction = new Transaction
            {
                TransactionType = "Transfer",
                Amount = amount,
                Currency = sourceAccount.Currency,
                DateTime = DateTime.UtcNow,
                SourceAccountId = sourceAccountId,
                DestinationAccountId = destinationAccountId
            };

            await _transactionService.AddAsync(transaction);
            await _accountService.UpdateAsync(sourceAccount);
            await _accountService.UpdateAsync(destinationAccount);
        }

        public async Task MakeWithdrawal(Guid accountId, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.", nameof(amount));
            }

            var account = await _accountService.GetByIdAsync(accountId);
            if (account == null)
            {
                throw new InvalidOperationException("Account not found.");
            }

            if (account.Balance < amount)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }

            account.Balance -= amount;

            var transaction = new Transaction
            {
                TransactionType = "Withdrawal",
                Amount = amount,
                Currency = account.Currency,
                DateTime = DateTime.UtcNow,
                SourceAccountId = accountId,
                DestinationAccountId = accountId
            };

            await _transactionService.AddAsync(transaction);
            await _accountService.UpdateAsync(account);
        }
    }
}
