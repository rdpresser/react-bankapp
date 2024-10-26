using ReactBank.Application.Account.Commands.CreateAccountCommand;
using ReactBank.Application.Account.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Account.Abstractions
{
    public interface IAccountAppService
    {
        CreateAccountCommand MapDataRequestToCommand(AccountDataRequest accountDataRequest);
        Task<Result<AccountDataResponse>> CreateAccountAsync(AccountDataRequest accountDataRequest);
    }
}
