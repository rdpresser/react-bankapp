using MediatR;
using ReactBank.Application.Commons.Bases.Interfaces.Validations;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Operation.Commands.MakeDepositOperationCommand
{
    public class MakeDepositOperationHandler : IRequestHandler<MakeDepositOperationCommand, Result<Guid>>
    {
        private readonly IAccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseValidation<MakeDepositOperationCommand> _validator;
        private readonly ITransactionService _transactionService;

        public MakeDepositOperationHandler(IUnitOfWork unitOfWork, IAccountService accountService, ITransactionService transactionService, IBaseValidation<MakeDepositOperationCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
            _transactionService = transactionService;
            _validator = validator;
        }

        public async Task<Result<Guid>> Handle(MakeDepositOperationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _validator.IsValidAsync(request);
                if (!result.IsValid)
                {
                    return Result<Guid>.Failure(result.ToDictionary());
                }

                (Guid accountId, decimal amount) = (request.AccountId, request.Amount);

                var account = await _accountService.GetByIdAsync(accountId);
                if (account == null)
                {
                    return Result<Guid>.Failure(new Dictionary<string, string[]> { { "MakeDepositOperationCommand", ["Account not found"] } });
                }

                account.Balance += amount;

                var transaction = new Domain.Models.Transaction
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
                await _unitOfWork.CommitAsync();

                return Result<Guid>.Success(account.Id);
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure(new Dictionary<string, string[]> { { "MakeDepositOperationCommand", [ex.Message] } });
            }
        }
    }
}
