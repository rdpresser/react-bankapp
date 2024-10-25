using ReactBank.Application.CustomAttributes;

namespace ReactBank.Application.DataContracts
{
    public class TakeLoanOperationDataRequest
    {
        [RequiredGuidValidation]
        public Guid AccountId { get; set; }
        [RequiredValidation]
        public decimal Amount { get; set; }
        [RequiredValidation]
        public decimal InterestRate { get; set; }
        [RequiredValidation]
        public DateTime StartDate { get; set; } = DateTime.UtcNow; // Default value for "StartDate"
        [RequiredValidation]
        public DateTime EndDate { get; set; } = DateTime.UtcNow.AddMonths(3); // Default value for "EndDate"
    }
}
