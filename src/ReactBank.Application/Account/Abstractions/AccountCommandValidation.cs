using FluentValidation;
using ReactBank.Application.Account.Commands.CreateAccountCommand;
using ReactBank.Application.Commons.Bases.Validations;

namespace ReactBank.Application.Account.Abstractions
{
    public class AccountCommandValidation : BaseValidation<CreateAccountCommand>
    {
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
