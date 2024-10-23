using ReactBank.Domain.Core.Models;

namespace ReactBank.Domain.Models
{
    public class Transaction : BaseEntity
    {
        public string TransactionType { get; set; } //Create enum for TransactionType (Deposit, Withdrawal, Transfer, Payment, Salary, Loan, Investment, Mortgage, Credit, Debit)
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "US$"; // Default value for "Currency
        public DateTime DateTime { get; set; } = DateTime.UtcNow; // Default value for "DateTime"

        public Guid SourceAccountId { get; set; }
        public virtual Account SourceAccount { get; set; }

        public Guid DestinationAccountId { get; set; }
        public virtual Account DestinationAccount { get; set; }
    }
}
