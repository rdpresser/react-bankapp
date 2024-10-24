namespace ReactBank.Application.DataContracts
{
    public class AccountDataRequest
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; } = "US$"; // Default value for "Currency
        public string AccountType { get; set; } //Create enum for AccountType (Checking Account, Savings Account, Business Account, Joint Account, Investment Account, Student Account, Salary Account)

        public Guid CustomerId { get; set; }
    }
}
