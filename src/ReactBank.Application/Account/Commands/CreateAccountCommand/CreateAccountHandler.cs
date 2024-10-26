using MediatR;
using ReactBank.Application.Account.DataContracts;
using ReactBank.Application.Commons.Bases.Interfaces.Validations;
using ReactBank.Domain.Core.Notifications;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Account.Commands.CreateAccountCommand
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, Result<AccountDataResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;
        private readonly IBaseValidation<CreateAccountCommand> _validator;

        public CreateAccountHandler(IUnitOfWork unitOfWork, IAccountService accountService, IBaseValidation<CreateAccountCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
            _validator = validator;
        }

        public async Task<Result<AccountDataResponse>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _validator.IsValidAsync(request);
                if (!result.IsValid)
                {
                    return Result<AccountDataResponse>.Failure(_validator.Errors(result));
                }

                var account = new Domain.Models.Account
                {
                    AccountNumber = request.AccountNumber,
                    Balance = request.Balance,
                    Currency = request.Currency,
                    AccountType = request.AccountType,
                    CustomerId = request.CustomerId
                };

                await _accountService.AddAsync(account);
                await _unitOfWork.CommitAsync(cancellationToken);

                return Result<AccountDataResponse>.Success(new AccountDataResponse(
                    Id: account.Id,
                    AccountNumber: account.AccountNumber,
                    Balance: account.Balance,
                    Currency: account.Currency,
                    AccountType: account.AccountType
                ));
            }
            catch (Exception ex)
            {
                //Create extension 
                return Result<AccountDataResponse>.Failure(new Dictionary<string, string> { { "CreateAccountCommand", ex.Message } });
            }
        }
    }
}
