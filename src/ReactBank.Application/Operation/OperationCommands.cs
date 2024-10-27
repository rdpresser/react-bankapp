namespace ReactBank.Application.Operation
{
    /// <summary>
    /// Make a transfer operation
    /// </summary>
    /// <param name="SourceAccountId"></param>
    /// <param name="DestinationAccountId"></param>
    /// <param name="Amount"></param>
    public record MakeTransferOperationCommand(
        Guid SourceAccountId,
        Guid DestinationAccountId,
        decimal Amount
    );

    /// <summary>
    /// Make a withdrawal operation
    /// </summary>
    /// <param name="AccountId"></param>
    /// <param name="Amount"></param>
    public record MakeWithdrawalOperationCommand(
        Guid AccountId,
        decimal Amount
    );

    /// <summary>
    /// Take a loan operation
    /// </summary>
    /// <param name="AccountId"></param>
    /// <param name="Amount"></param>
    /// <param name="InterestRate"></param>
    /// <param name="StartDate"></param>
    /// <param name="EndDate"></param>
    public record TakeLoanOperationDataRequest(
        Guid AccountId,
        decimal Amount,
        decimal InterestRate,
        DateTime StartDate,
        DateTime EndDate
    );
}
