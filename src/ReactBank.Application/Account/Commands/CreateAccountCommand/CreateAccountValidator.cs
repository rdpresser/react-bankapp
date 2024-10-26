using ReactBank.Application.Account.Abstractions;
using ReactBank.Application.Commons.Bases.Interfaces.Validations;

namespace ReactBank.Application.Account.Commands.CreateAccountCommand
{
    public class CreateAccountValidator : AccountCommandValidation, IBaseValidation<CreateAccountCommand>
    {
        public CreateAccountValidator()
        {
            ValidateAccountNumber();
            ValidateBalance();
            ValidateCustomerId();
            ValidateCurrency();
            ValidateAccountType();
        }
    }
}
