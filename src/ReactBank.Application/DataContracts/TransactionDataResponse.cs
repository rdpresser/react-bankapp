namespace ReactBank.Application.DataContracts
{
    public class TransactionDataResponse
    {
        public Guid Id { get; set; }
        public string TransactionType { get; set; } //Create enum for TransactionType (Deposit, Withdrawal, Transfer, Payment, Salary, Loan, Investment, Mortgage, Credit, Debit)
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime DateTime { get; set; }
        public Guid SourceAccountId { get; set; }
        public Guid DestinationAccountId { get; set; }
    }
}
