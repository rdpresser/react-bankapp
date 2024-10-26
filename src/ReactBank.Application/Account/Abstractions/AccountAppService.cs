using MediatR;
using ReactBank.Application.Account.Commands.CreateAccountCommand;
using ReactBank.Application.Account.DataContracts;
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
                dataContract.AccountNumber,
                dataContract.Balance,
                dataContract.Currency,
                dataContract.AccountType,
                dataContract.CustomerId
            );
        }

        public async Task<Result<AccountDataResponse>> CreateAccountAsync(AccountDataRequest accountDataRequest)
        {
            Result<AccountDataResponse> result = await _mediator.Send(MapDataRequestToCommand(accountDataRequest));

            return result;
        }
    }
}
