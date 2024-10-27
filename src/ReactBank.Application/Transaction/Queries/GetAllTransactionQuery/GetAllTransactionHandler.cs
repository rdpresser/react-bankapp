using MediatR;
using ReactBank.Application.Transaction.DataContracts;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Transaction.Queries.GetAllTransactionQuery
{
    public class GetAllTransactionHandler : IRequestHandler<GetAllTransactionQuery, Result<IEnumerable<TransactionDataResponse>>>
    {
        private readonly ITransactionService _transactionService;

        public GetAllTransactionHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<Result<IEnumerable<TransactionDataResponse>>> Handle(GetAllTransactionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var transactions = await _transactionService.GetAllAsync();
                if (transactions == null || !transactions.Any())
                {
                    return Result<IEnumerable<TransactionDataResponse>>.NotFound(new Dictionary<string, string[]> { { "Transactions", ["No transactions found."] } });
                }

                var transactionDataResponses = transactions.Select(transaction => new TransactionDataResponse(
                    Id: transaction.Id,
                    TransactionType: transaction.TransactionType,
                    Amount: transaction.Amount,
                    Currency: transaction.Currency,
                    DateTime: transaction.DateTime.ToString("MMMM dd, yyyy HH:mm"),
                    SourceAccount: $"{transaction.SourceAccount.Customer.Name} - {transaction.SourceAccountId}",
                    DestinationAccount: $"{transaction.DestinationAccount.Customer.Name} - {transaction.DestinationAccountId}"
                ));

                return Result<IEnumerable<TransactionDataResponse>>.Success(transactionDataResponses);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<TransactionDataResponse>>.Failure(new Dictionary<string, string[]> { { "Error", [ex.Message] } });
            }
        }
    }
}
