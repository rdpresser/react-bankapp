using ReactBank.Application.CustomAttributes;

namespace ReactBank.Application.DataContracts
{
    public class MakeWithdrawOperationDataRequest
    {
        [RequiredGuidValidation]
        public Guid AccountId { get; set; }
        [RequiredValidation]
        public decimal Amount { get; set; }
    }
}
