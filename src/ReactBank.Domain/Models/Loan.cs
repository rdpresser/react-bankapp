using ReactBank.Domain.Core.Models;

namespace ReactBank.Domain.Models
{
    public class Loan : BaseEntity
    {
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow; // Default value for "StartDate"
        public DateTime EndDate { get; set; }

        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
