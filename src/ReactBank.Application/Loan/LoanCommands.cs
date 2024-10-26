namespace ReactBank.Application.Loan
{
    /// <summary>
    /// Create a new loan
    /// </summary>
    /// <param name="Amount"></param>
    /// <param name="InterestRate"></param>
    /// <param name="StartDate"></param>
    /// <param name="EndDate"></param>
    /// <param name="AccountId"></param>
    public record CreateLoanCommand(
       decimal Amount,
       decimal InterestRate,
       DateTime StartDate,
       DateTime EndDate,
       Guid AccountId
    );

    /// <summary>
    /// Update an existing loan
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Amount"></param>
    /// <param name="InterestRate"></param>
    /// <param name="StartDate"></param>
    /// <param name="EndDate"></param>
    public record UpdateLoanCommand(
        Guid Id,
        decimal Amount,
        decimal InterestRate,
        DateTime StartDate,
        DateTime EndDate
    );

    /// <summary>
    /// Delete an existing loan
    /// </summary>
    /// <param name="Id"></param>
    public record DeleteLoanCommand(
        Guid Id
    );
}
