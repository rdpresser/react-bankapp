namespace ReactBank.Application.DataContracts
{
    public class AccountDataResponse
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public string AccountType { get; set; } //Create enum for AccountType (Checking Account, Savings Account, Business Account, Joint Account, Investment Account, Student Account, Salary Account)
    }
}
