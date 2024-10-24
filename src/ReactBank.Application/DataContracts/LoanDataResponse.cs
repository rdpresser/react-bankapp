namespace ReactBank.Application.DataContracts
{
    public class LoanDataResponse
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid AccountId { get; set; }
    }
}
