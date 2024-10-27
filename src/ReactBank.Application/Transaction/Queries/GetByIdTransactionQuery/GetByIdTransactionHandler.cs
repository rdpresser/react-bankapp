using MediatR;
using ReactBank.Application.Transaction.DataContracts;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Transaction.Queries.GetByIdTransactionQuery
{
    public class GetByIdTransactionHandler : IRequestHandler<GetByIdTransactionQuery, Result<TransactionDataResponse>>
    {
        private readonly ITransactionService _transactionService;

        public GetByIdTransactionHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<Result<TransactionDataResponse>> Handle(GetByIdTransactionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var transaction = await _transactionService.GetByIdAsync(request.Id);
                if (transaction == null)
                {
                    var errors = new Dictionary<string, string[]>
                    {
                        { "Transaction", ["Transaction not found."] }
                    };
                    return Result<TransactionDataResponse>.NotFound(errors);
                }

                return Result<TransactionDataResponse>.Success(new TransactionDataResponse(
                    Id: transaction.Id,
                    TransactionType: transaction.TransactionType,
                    Amount: transaction.Amount,
                    Currency: transaction.Currency,
                    DateTime: transaction.DateTime.ToString("MMMM dd, yyyy HH:mm"),
                    SourceAccount: $"{transaction.SourceAccount.Customer.Name} - {transaction.SourceAccountId}",
                    DestinationAccount: $"{transaction.DestinationAccount.Customer.Name} - {transaction.DestinationAccountId}"
                ));
            }
            catch (Exception ex)
            {
                return Result<TransactionDataResponse>.Failure(new Dictionary<string, string[]> { { "GetByIdTransactionQuery", [ex.Message] } });
            }
        }
    }
}
