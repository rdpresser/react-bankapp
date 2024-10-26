using MediatR;
using ReactBank.Application.Account.DataContracts;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Account.Queries.GetByIdAccountQuery
{
    public class GetByIdAccountHandler : IRequestHandler<GetByIdAccountQuery, Result<AccountDataResponse>>
    {
        private readonly IAccountService _accountService;

        public GetByIdAccountHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Result<AccountDataResponse>> Handle(GetByIdAccountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var account = await _accountService.GetByIdAsync(request.Id);
                if (account != null)
                {
                    return Result<AccountDataResponse>.Success(new AccountDataResponse(
                        Id: account.Id,
                        AccountNumber: account.AccountNumber,
                        Balance: account.Balance,
                        Currency: account.Currency,
                        AccountType: account.AccountType,
                        CustomerId: account.CustomerId
                    ));
                }
                return Result<AccountDataResponse>.Failure(new Dictionary<string, string> { { "GetByIdAccountQuery", "Account not found" } });
            }
            catch (Exception ex)
            {
                return Result<AccountDataResponse>.Failure(new Dictionary<string, string> { { "GetByIdAccountQuery", ex.Message } });
            }
        }
    }

}
