using MediatR;
using ReactBank.Application.Account.DataContracts;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Account.Queries.GetAllAccountQuery
{
    public class GetAllAccountHandler(IAccountService accountService) : IRequestHandler<GetAllAccountQuery, Result<IEnumerable<AccountDataResponse>>>
    {
        private readonly IAccountService _accountService = accountService;

        public async Task<Result<IEnumerable<AccountDataResponse>>> Handle(GetAllAccountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var accounts = await _accountService.GetAllAsync();
                if (accounts != null)
                {
                    return Result<IEnumerable<AccountDataResponse>>.Success(accounts.Select(account => new AccountDataResponse(
                        Id: account.Id,
                        AccountNumber: account.AccountNumber,
                        Balance: account.Balance,
                        Currency: account.Currency,
                        AccountType: account.AccountType,
                        CustomerId: account.CustomerId
                    )));
                }
                return Result<IEnumerable<AccountDataResponse>>.Failure(new Dictionary<string, string> { { "GetAllAccountQuery", "No accounts found" } });
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<AccountDataResponse>>.Failure(new Dictionary<string, string> { { "GetAllAccountQuery", ex.Message } });
            }
        }
    }
}
