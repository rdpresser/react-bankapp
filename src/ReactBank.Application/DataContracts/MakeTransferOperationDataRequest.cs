using ReactBank.Application.CustomAttributes;

namespace ReactBank.Application.DataContracts
{
    public class MakeTransferOperationDataRequest
    {
        [RequiredGuidValidation]
        public Guid SourceAccountId { get; set; }
        [RequiredGuidValidation]
        public Guid DestinationAccountId { get; set; }
        [RequiredValidation]
        public decimal Amount { get; set; }
    }
}
