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
                .NotEmpty().WithMessage("Account number must not be empty")
                .MaximumLength(50).WithMessage("Account number must not exceed 50 characters");
        }

        protected void ValidateBalance()
        {
            RuleFor(x => x.Balance)
                .GreaterThanOrEqualTo(0).WithMessage("Balance must be greater than or equal to 0");
        }

        protected void ValidateCustomerId()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer ID must not be empty");
        }

        protected void ValidateCurrency()
        {
            RuleFor(x => x.Currency)
                .NotEmpty().WithMessage("Currency must not be empty")
                .MaximumLength(3).WithMessage("Currency must not exceed 3 characters");
        }

        protected void ValidateAccountType()
        {
            RuleFor(x => x.AccountType)
                .IsInEnum().WithMessage("Invalid account type");
        }
    }
}
