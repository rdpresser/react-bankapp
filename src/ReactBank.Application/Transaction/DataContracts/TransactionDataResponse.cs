namespace ReactBank.Application.Transaction.DataContracts
{
    /// <summary>
    /// Represents the response data contract for the transaction data.
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="TransactionType"></param>
    /// <param name="Amount"></param>
    /// <param name="Currency"></param>
    /// <param name="DateTime"></param>
    /// <param name="SourceAccount"></param>
    /// <param name="DestinationAccount"></param>
    public record TransactionDataResponse(
        Guid Id,
        string TransactionType,
        decimal Amount,
        string Currency,
        string DateTime,
        string SourceAccount,
        string DestinationAccount
    );
}
