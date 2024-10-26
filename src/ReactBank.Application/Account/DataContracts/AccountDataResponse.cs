using ReactBank.Domain.Enums;

namespace ReactBank.Application.Account.DataContracts
{
    public record AccountDataResponse
    (
        Guid Id,
        string AccountNumber,
        decimal Balance,
        string Currency,
        AccountType AccountType
    );

    //public class AccountDataResponse
    //{
    //    public Guid Id { get; set; }
    //    public string AccountNumber { get; set; }
    //    public decimal Balance { get; set; }
    //    public string Currency { get; set; }
    //    public string AccountType { get; set; } //Create enum for AccountType (Checking Account, Savings Account, Business Account, Joint Account, Investment Account, Student Account, Salary Account)
    //}
}
