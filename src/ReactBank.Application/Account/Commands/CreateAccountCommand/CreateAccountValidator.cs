using ReactBank.Application.Account.Abstractions;
using ReactBank.Application.Commons.Bases.Interfaces.Validations;
using ReactBank.Application.Customer.Abstractions;

namespace ReactBank.Application.Account.Commands.CreateAccountCommand
{
    public class CreateAccountValidator : AccountCommandValidation, IBaseValidation<CreateAccountCommand>
    {
        public CreateAccountValidator(ICustomerAppService customerAppService, IAccountAppService accountAppService)
            : base(customerAppService, accountAppService)
        {
            ValidateAccountNumber();
            ValidateBalance();
            ValidateCustomerId();
            ValidateCurrency();
            ValidateAccountType();
            ValidateIfCustomerExists();
            ValidateIfAccountNumberExists();
        }
    }
}
