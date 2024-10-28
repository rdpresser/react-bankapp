using MediatR;
using ReactBank.Application.Loan.Abstractions;
using ReactBank.Application.Loan.DataContracts;
using ReactBank.Application.Loan.Queries.GetAllLoanQuery;
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

        public Task<Result<LoanDataResponse>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
