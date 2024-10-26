using MediatR;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Account.Queries.GetByAccountNumberAccountQuery
{
    public class GetByAccountNumberAccountHandler : IRequestHandler<GetByAccountNumberAccountQuery, Result<bool>>
    {
        private readonly IAccountService _accountService;

        public GetByAccountNumberAccountHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Result<bool>> Handle(GetByAccountNumberAccountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var exists = await _accountService.ExistsAccountNumberAsync(request.AccountNumber);
                if (exists)
                {
                    return Result<bool>.Success(true);
                }
                return Result<bool>.Failure(new Dictionary<string, string> { { "GetByAccountNumberAccountQuery", "Account not found" } });
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure(new Dictionary<string, string> { { "GetByAccountNumberAccountQuery", ex.Message } });
            }
        }
    }
}
