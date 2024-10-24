namespace ReactBank.Application.DataContracts
{
    public class MakeDepositOperationDataRequest
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
