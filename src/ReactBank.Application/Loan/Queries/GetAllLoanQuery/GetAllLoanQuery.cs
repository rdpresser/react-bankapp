using MediatR;
using ReactBank.Application.Loan.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Loan.Queries.GetAllLoanQuery
{
    public record GetAllLoanQuery() : IRequest<Result<IEnumerable<LoanDataResponse>>>;
}
