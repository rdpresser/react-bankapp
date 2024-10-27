using MediatR;
using ReactBank.Application.Commons.Bases.Interfaces.Validations;
using ReactBank.Application.Loan.DataContracts;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Loan.Commands.CreateLoanCommand
{
    public class CreateLoanHandler : IRequestHandler<CreateLoanCommand, Result<LoanDataResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;
        private readonly ILoanService _loanService;
        private readonly IBaseValidation<CreateLoanCommand> _validator;

        public CreateLoanHandler(IUnitOfWork unitOfWork, IAccountService accountService, ITransactionService transactionService,
            ILoanService loanService, IBaseValidation<CreateLoanCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService), $"{nameof(accountService)} could not be null");
            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService), $"{nameof(transactionService)} could not be null");
            _loanService = loanService ?? throw new ArgumentNullException(nameof(loanService), $"{nameof(loanService)} could not be null");
            _validator = validator;
        }

        public async Task<Result<LoanDataResponse>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Validate the request
                var validationResult = await _validator.IsValidAsync(request);
                if (!validationResult.IsValid)
                {
                    return Result<LoanDataResponse>.Failure(validationResult.ToDictionary());
                }

                var account = await _accountService.GetByIdAsync(request.AccountId);
                if (account == null)
                {
                    return Result<LoanDataResponse>.Failure(new Dictionary<string, string[]> { { "CreateLoanCommand", ["Account not found"] } });
                }

                //Add the loan amount to the account balance
                account.Balance += request.Amount;

                var transaction = new Domain.Models.Transaction
                {
                    TransactionType = "Loan",
                    Amount = request.Amount,
                    Currency = account.Currency,
                    DateTime = DateTime.UtcNow,
                    SourceAccountId = request.AccountId,
                    DestinationAccountId = request.AccountId
                };

                // Create a new loan entity
                var loan = new Domain.Models.Loan
                {
                    Amount = request.Amount,
                    InterestRate = request.InterestRate,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    AccountId = request.AccountId
                };

                // Add the loan using the loan service
                await _transactionService.AddAsync(transaction);
                await _accountService.UpdateAsync(account);
                await _loanService.AddAsync(loan);

                // Commit the transaction
                var commitResult = await _unitOfWork.CommitAsync(cancellationToken);
                if (!commitResult)
                {
                    return Result<LoanDataResponse>.Failure(new Dictionary<string, string[]> { { "CreateLoanCommand|Commit", ["Failed to commit transaction"] } });
                }

                // Create the response
                var response = new LoanDataResponse
                {
                    Id = loan.Id,
                    Amount = loan.Amount,
                    InterestRate = loan.InterestRate,
                    StartDate = loan.StartDate,
                    EndDate = loan.EndDate,
                    AccountId = loan.AccountId
                };

                return Result<LoanDataResponse>.Success(response);
            }
            catch (Exception ex)
            {
                return Result<LoanDataResponse>.Failure(new Dictionary<string, string[]> { { "CreateLoanCommand", [ex.Message] } });
            }
        }
    }
}
