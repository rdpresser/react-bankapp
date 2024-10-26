using MediatR;
using ReactBank.Application.Account.Commands.CreateAccountCommand;
using ReactBank.Application.Account.DataContracts;
using ReactBank.Application.Account.Queries.GetAllAccountQuery;
using ReactBank.Application.Account.Queries.GetByAccountNumberAccountQuery;
using ReactBank.Application.Account.Queries.GetByIdAccountQuery;
using ReactBank.Application.Account.Queries.GetByIdExistsAccountQuery;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Account.Abstractions
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IMediator _mediator;

        public AccountAppService(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public CreateAccountCommand MapDataRequestToCommand(AccountDataRequest dataContract)
        {
            return new CreateAccountCommand(
                AccountNumber: dataContract.AccountNumber,
                Balance: dataContract.Balance,
                Currency: dataContract.Currency,
                AccountType: dataContract.AccountType,
                CustomerId: dataContract.CustomerId
            );
        }

        public async Task<Result<AccountDataResponse>> CreateAccountAsync(AccountDataRequest accountDataRequest)
        {
            return await _mediator.Send(MapDataRequestToCommand(accountDataRequest));
        }

        public async Task<Result<bool>> Exists(Guid id)
        {
            return await _mediator.Send(new GetByIdExistsAccountQuery(id));
        }

        public async Task<Result<bool>> ExistsAccountNumber(string accountNumber)
        {
            return await _mediator.Send(new GetByAccountNumberAccountQuery(accountNumber));
        }

        public async Task<Result<AccountDataResponse>> GetByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetByIdAccountQuery(id));
        }

        public async Task<Result<IEnumerable<AccountDataResponse>>> GetAllAsync()
        {
            return await _mediator.Send(new GetAllAccountQuery());
        }
    }
}
