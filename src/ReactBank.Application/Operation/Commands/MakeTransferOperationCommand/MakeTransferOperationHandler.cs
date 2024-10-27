using MediatR;
using ReactBank.Application.Commons.Bases.Interfaces.Validations;
using ReactBank.Application.Operation.DataContracts;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Operation.Commands.MakeTransferOperationCommand
{
    public class MakeTransferOperationHandler : IRequestHandler<MakeTransferOperationCommand, Result<DefaultOperationDataResponse>>
    {
        private readonly IAccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseValidation<MakeTransferOperationCommand> _validator;
        private readonly ITransactionService _transactionService;

        public MakeTransferOperationHandler(IUnitOfWork unitOfWork, IAccountService accountService, ITransactionService transactionService, IBaseValidation<MakeTransferOperationCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
            _transactionService = transactionService;
            _validator = validator;
        }

        public async Task<Result<DefaultOperationDataResponse>> Handle(MakeTransferOperationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _validator.IsValidAsync(request);
                if (!result.IsValid)
                {
                    return Result<DefaultOperationDataResponse>.Failure(result.ToDictionary());
                }

                var sourceAccount = await _accountService.GetByIdAsync(request.SourceAccountId);
                var destinationAccount = await _accountService.GetByIdAsync(request.DestinationAccountId);

                if (sourceAccount == null || destinationAccount == null)
                {
                    var errors = new Dictionary<string, string[]>
                    {
                        { "Account", new[] { "Source or destination account not found." } }
                    };
                    return Result<DefaultOperationDataResponse>.Failure(errors);
                }

                if (sourceAccount.Balance < request.Amount)
                {
                    var errors = new Dictionary<string, string[]>
                    {
                        { "SourceAccount", new[] { "Insufficient funds in source account." } }
                    };
                    return Result<DefaultOperationDataResponse>.Failure(errors);
                }

                sourceAccount.Balance -= request.Amount;
                destinationAccount.Balance += request.Amount;

                var transaction = new Domain.Models.Transaction
                {
                    TransactionType = "Transfer",
                    Amount = request.Amount,
                    Currency = sourceAccount.Currency,
                    DateTime = DateTime.UtcNow,
                    SourceAccountId = request.SourceAccountId,
                    DestinationAccountId = request.DestinationAccountId
                };

                var newTransaction = await _transactionService.AddAsync(transaction);
                await _accountService.UpdateAsync(sourceAccount);
                await _accountService.UpdateAsync(destinationAccount);
                await _unitOfWork.CommitAsync();

                return Result<DefaultOperationDataResponse>.Success(new DefaultOperationDataResponse(newTransaction.Id));
            }
            catch (Exception ex)
            {
                return Result<DefaultOperationDataResponse>.Failure(new Dictionary<string, string[]> { { "MakeTransferOperationCommand", [ex.Message] } });
            }
        }
    }
}
