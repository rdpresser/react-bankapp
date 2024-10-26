using FluentValidation;
using ReactBank.Application.Account.Commands.CreateAccountCommand;
using ReactBank.Application.Commons.Bases.Validations;
using ReactBank.Application.Customer.Abstractions;

namespace ReactBank.Application.Account.Abstractions
{
    public class AccountCommandValidation : BaseValidation<CreateAccountCommand>
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly IAccountAppService _accountAppService;

        public AccountCommandValidation(ICustomerAppService customerAppService, IAccountAppService accountAppService)
        {
            _customerAppService = customerAppService;
            _accountAppService = accountAppService;
        }

        protected void ValidateIfAccountNumberExists()
        {
            RuleFor(x => x.AccountNumber)
                .MustAsync(async (accountNumber, cancellationToken) =>
                {
                    var result = await _accountAppService.ExistsAccountNumber(accountNumber);
                    return !result.IsSuccess;
                })
                .WithMessage("Account number already exists");
        }

        protected void ValidateIfCustomerExists()
        {
            RuleFor(x => x.CustomerId)
                .MustAsync(async (customerId, cancellationToken) =>
                {
                    var result = await _customerAppService.Exists(customerId);
                    return result.IsSuccess;
                })
                .WithMessage("Customer not found");
        }

        protected void ValidateAccountNumber()
        {
            RuleFor(x => x.AccountNumber)
                .NotEmpty()
                .MaximumLength(50);
        }

        protected void ValidateBalance()
        {
            RuleFor(x => x.Balance)
                .GreaterThanOrEqualTo(0);
        }

        protected void ValidateCustomerId()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty();
        }

        protected void ValidateCurrency()
        {
            RuleFor(x => x.Currency)
                .NotEmpty()
                .MaximumLength(3);
        }

        protected void ValidateAccountType()
        {
            RuleFor(x => x.AccountType)
                .IsInEnum();
        }
    }
}
