namespace ReactBank.Application.Loan.DataContracts
{
    public record LoanDataResponse(
        Guid Id,
        decimal Amount,
        decimal InterestRate,
        DateTime StartDate,
        DateTime EndDate,
        Guid AccountId,
        Guid TransactionId
    );
}
