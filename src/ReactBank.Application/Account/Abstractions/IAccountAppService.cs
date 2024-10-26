using ReactBank.Application.Account.Commands.CreateAccountCommand;
using ReactBank.Application.Account.DataContracts;
using ReactBank.Domain.Core.Notifications;

namespace ReactBank.Application.Account.Abstractions
{
    public interface IAccountAppService
    {
        CreateAccountCommand MapDataRequestToCommand(AccountDataRequest accountDataRequest);
        Task<Result<AccountDataResponse>> CreateAccountAsync(AccountDataRequest accountDataRequest);
        Task<Result<bool>> Exists(Guid id);
        Task<Result<bool>> ExistsAccountNumber(string accountNumber);
        Task<Result<AccountDataResponse>> GetByIdAsync(Guid id);
        Task<Result<IEnumerable<AccountDataResponse>>> GetAllAsync();
    }
}
