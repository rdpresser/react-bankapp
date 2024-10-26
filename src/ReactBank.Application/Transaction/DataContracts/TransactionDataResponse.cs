namespace ReactBank.Application.Transaction.DataContracts
{
    public class TransactionDataResponse
    {
        public Guid Id { get; set; }
        public string TransactionType { get; set; } //Create enum for TransactionType (Deposit, Withdrawal, Transfer, Payment, Salary, Loan, Investment, Mortgage, Credit, Debit)
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string DateTime { get; set; }
        public string SourceAccount { get; set; }
        public string DestinationAccount { get; set; }
    }
}
