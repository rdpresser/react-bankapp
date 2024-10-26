using ReactBank.Application.CustomAttributes;

namespace ReactBank.Application.Loan.DataContracts
{
    public class LoanDataRequest
    {
        [RequiredValidation]
        public decimal Amount { get; set; }
        [RequiredValidation]
        public decimal InterestRate { get; set; }
        [RequiredValidation]
        public DateTime StartDate { get; set; } = DateTime.UtcNow; // Default value for "StartDate"
        [RequiredValidation]
        public DateTime EndDate { get; set; }
        [RequiredGuidValidation]
        public Guid AccountId { get; set; }
    }
}
