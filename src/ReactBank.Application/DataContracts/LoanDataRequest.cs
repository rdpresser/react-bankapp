namespace ReactBank.Application.DataContracts
{
    public class LoanDataRequest
    {
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow; // Default value for "StartDate"
        public DateTime EndDate { get; set; }
        public Guid AccountId { get; set; }
    }
}
