using MediatR;
using ReactBank.Application.Loan.DataContracts;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Loan.Queries.GetAllLoanQuery
{
    public class GetAllLoanHandler : IRequestHandler<GetAllLoanQuery, Result<IEnumerable<LoanDataResponse>>>
    {
        private readonly ILoanService _loanService;

        public GetAllLoanHandler(ILoanService loanService)
        {
            _loanService = loanService;
        }

        public async Task<Result<IEnumerable<LoanDataResponse>>> Handle(GetAllLoanQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var loans = await _loanService.GetAllAsync();
                if (loans != null)
                {
                    return Result<IEnumerable<LoanDataResponse>>.Success(loans.Select(loan => new LoanDataResponse(
                        Id: loan.Id,
                        Amount: loan.Amount,
                        InterestRate: loan.InterestRate,
                        StartDate: loan.StartDate,
                        EndDate: loan.EndDate,
                        AccountId: loan.AccountId,
                        TransactionId: Guid.Empty,
                        CustomerName: loan.Account.Customer.Name
                    )));
                }

                return Result<IEnumerable<LoanDataResponse>>.NotFound(new Dictionary<string, string[]> { { "GetAllLoanQuery", ["No loans found"] } });
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<LoanDataResponse>>.Failure(new Dictionary<string, string[]> { { "GetAllLoanQuery", [ex.Message] } });
            }
        }
    }
}
