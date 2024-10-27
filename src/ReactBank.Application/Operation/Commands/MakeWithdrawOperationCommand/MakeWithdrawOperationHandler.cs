using MediatR;
using ReactBank.Application.Commons.Bases.Interfaces.Validations;
using ReactBank.Application.Operation.DataContracts;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Operation.Commands.MakeWithdrawOperationCommand
{
    public class MakeWithdrawOperationHandler : IRequestHandler<MakeWithdrawOperationCommand, Result<DefaultOperationDataResponse>>
    {
        private readonly IAccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseValidation<MakeWithdrawOperationCommand> _validator;
        private readonly ITransactionService _transactionService;

        public MakeWithdrawOperationHandler(IUnitOfWork unitOfWork, IAccountService accountService, ITransactionService transactionService, IBaseValidation<MakeWithdrawOperationCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
            _transactionService = transactionService;
            _validator = validator;
        }

        public async Task<Result<DefaultOperationDataResponse>> Handle(MakeWithdrawOperationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _validator.IsValidAsync(request);
                if (!result.IsValid)
                {
                    return Result<DefaultOperationDataResponse>.Failure(result.ToDictionary());
                }

                var account = await _accountService.GetByIdAsync(request.AccountId);
                if (account == null)
                {
                    var errors = new Dictionary<string, string[]>
                    {
                        { "Account", ["Account not found."] }
                    };
                    return Result<DefaultOperationDataResponse>.Failure(errors);
                }

                if (account.Balance < request.Amount)
                {
                    var errors = new Dictionary<string, string[]>
                    {
                        { "Account", ["Insufficient funds."] }
                    };
                    return Result<DefaultOperationDataResponse>.Failure(errors);
                }

                account.Balance -= request.Amount;

                var transaction = new Domain.Models.Transaction
                {
                    TransactionType = "Withdrawal",
                    Amount = request.Amount,
                    Currency = account.Currency,
                    DateTime = DateTime.UtcNow,
                    SourceAccountId = request.AccountId,
                    DestinationAccountId = request.AccountId
                };

                var newTransaction = await _transactionService.AddAsync(transaction);
                await _accountService.UpdateAsync(account);
                await _unitOfWork.CommitAsync();

                return Result<DefaultOperationDataResponse>.Success(new DefaultOperationDataResponse(newTransaction.Id));
            }
            catch (Exception ex)
            {
                return Result<DefaultOperationDataResponse>.Failure(new Dictionary<string, string[]> { { "Exception", new[] { ex.Message } } });
            }
        }
    }
}
