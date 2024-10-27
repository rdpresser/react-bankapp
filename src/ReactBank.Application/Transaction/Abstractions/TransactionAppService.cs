using MediatR;
using ReactBank.Application.Transaction.Abstractions;
using ReactBank.Application.Transaction.DataContracts;
using ReactBank.Application.Transaction.Queries.GetAllTransactionQuery;
using ReactBank.Application.Transaction.Queries.GetByIdTransactionQuery;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Services
{
    public class TransactionAppService : ITransactionAppService
    {
        private readonly IMediator _mediator;

        public TransactionAppService(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator), $"{nameof(mediator)} could not be null");
        }

        public async Task<Result<IEnumerable<TransactionDataResponse>>> GetAllAsync()
        {
            return await _mediator.Send(new GetAllTransactionQuery());
        }

        public async Task<Result<TransactionDataResponse>> GetByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetByIdTransactionQuery(id));
        }
    }
}
