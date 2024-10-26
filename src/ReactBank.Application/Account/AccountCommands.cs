namespace ReactBank.Application.Account
{
    /// <summary>
    /// Update an existing account
    /// </summary>
    /// <param name="AccountNumber"></param>
    /// <param name="Balance"></param>
    /// <param name="Currency"></param>
    /// <param name="AccountType"></param>
    /// <param name="CustomerId"></param>
    public record UpdateAccountCommand(
        string AccountNumber,
        decimal Balance,
        string Currency,
        string AccountType,
        Guid CustomerId
    );

    /// <summary>
    /// Delete an existing account
    /// </summary>
    /// <param name="AccountNumber"></param>
    public record DeleteAccountCommand(
        string AccountNumber
    );
}