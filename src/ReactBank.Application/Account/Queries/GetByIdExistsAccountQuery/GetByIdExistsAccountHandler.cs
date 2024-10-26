using MediatR;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Account.Queries.GetByIdExistsAccountQuery
{
    public class GetByIdExistsAccountHandler : IRequestHandler<GetByIdExistsAccountQuery, Result<bool>>
    {
        private readonly IAccountService _accountService;

        public GetByIdExistsAccountHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Result<bool>> Handle(GetByIdExistsAccountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var exists = await _accountService.Exists(request.Id);
                if (exists)
                {
                    return Result<bool>.Success(true);
                }
                return Result<bool>.NotFound(new Dictionary<string, string> { { "GetByIdExistsAccountQuery", "Account not found" } });
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure(new Dictionary<string, string> { { "GetByIdExistsAccountQuery", ex.Message } });
            }
        }
    }
}
