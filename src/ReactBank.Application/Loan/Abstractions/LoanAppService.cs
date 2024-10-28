using MediatR;
using ReactBank.Application.Loan.Abstractions;
using ReactBank.Application.Loan.DataContracts;
using ReactBank.Application.Loan.Queries.GetAllLoanQuery;
using ReactBank.Application.Loan.Queries.GetByIdLoanQuery;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Services
{
    public class LoanAppService : ILoanAppService
    {
        private readonly IMediator _mediator;

        public LoanAppService(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator), $"{nameof(mediator)} could not be null");
        }

        public async Task<Result<IEnumerable<LoanDataResponse>>> GetAllAsync()
        {
            return await _mediator.Send(new GetAllLoanQuery());
        }

        public async Task<Result<LoanDataResponse>> GetByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetByIdLoanQuery(id));
        }
    }
}
