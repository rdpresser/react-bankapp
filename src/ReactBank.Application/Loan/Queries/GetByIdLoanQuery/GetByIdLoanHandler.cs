using MediatR;
using ReactBank.Application.Loan.DataContracts;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Repositores;

namespace ReactBank.Application.Loan.Queries.GetByIdLoanQuery
{
    public class GetByIdLoanHandler : IRequestHandler<GetByIdLoanQuery, Result<LoanDataResponse>>
    {
        private readonly ILoanRepository _loanRepository;

        public GetByIdLoanHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<Result<LoanDataResponse>> Handle(GetByIdLoanQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var loan = await _loanRepository.GetByIdAsync(request.Id);
                if (loan == null)
                {
                    return Result<LoanDataResponse>.NotFound(new Dictionary<string, string[]> { { "GetByIdLoanQuery", new[] { "Loan not found." } } });
                }

                var response = new LoanDataResponse(
                    Id: loan.Id,
                    Amount: loan.Amount,
                    InterestRate: loan.InterestRate,
                    StartDate: loan.StartDate,
                    EndDate: loan.EndDate,
                    AccountId: loan.AccountId,
                    TransactionId: Guid.Empty,
                    CustomerName: loan.Account.Customer.Name
                );

                return Result<LoanDataResponse>.Success(response);
            }
            catch (Exception ex)
            {
                return Result<LoanDataResponse>.Failure(new Dictionary<string, string[]> { { "GetByIdLoanQuery", new[] { ex.Message } } });
            }
        }
    }
}
