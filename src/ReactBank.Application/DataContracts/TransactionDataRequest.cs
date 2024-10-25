using ReactBank.Application.CustomAttributes;

namespace ReactBank.Application.DataContracts
{
    public class TransactionDataRequest
    {
        [RequiredValidation]
        public string TransactionType { get; set; } //Create enum for TransactionType (Deposit, Withdrawal, Transfer, Payment, Salary, Loan, Investment, Mortgage, Credit, Debit)
        [RequiredValidation]
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "US$"; // Default value for "Currency
        public DateTime DateTime { get; set; } = DateTime.UtcNow; // Default value for "DateTime"
        [RequiredGuidValidation]
        public Guid SourceAccountId { get; set; }
        [RequiredGuidValidation]
        public Guid DestinationAccountId { get; set; }
    }
}
