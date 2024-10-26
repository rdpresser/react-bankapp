using ReactBank.Domain.Enums;

namespace ReactBank.Application.Account.DataContracts
{
    /// <summary>
    /// Account data response
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="AccountNumber"></param>
    /// <param name="Balance"></param>
    /// <param name="Currency"></param>
    /// <param name="AccountType"></param>
    public record AccountDataResponse
    (
        Guid Id,
        string AccountNumber,
        decimal Balance,
        string Currency,
        AccountType AccountType,
        Guid CustomerId
    );
}
