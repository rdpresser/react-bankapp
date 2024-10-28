using MediatR;
using ReactBank.Application.Loan.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Loan.Queries.GetByIdLoanQuery
{
    public record GetByIdLoanQuery(Guid Id) : IRequest<Result<LoanDataResponse>>;
}
