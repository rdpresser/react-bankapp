using ReactBank.Application.Commons.Bases.Interfaces.Validations;
using ReactBank.Application.Customer.Abstractions;

namespace ReactBank.Application.Customer.Commands.CreateCustomerCommand
{
    public class CreateCustomerValidator : CustomerCommandValidation, IBaseValidation<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            ValidateName();
            ValidateEmail();
            ValidatePhone();
            ValidateStreetAddress();
            ValidateCity();
            ValidateState();
            ValidateZipCode();
            ValidateDateOfBirth();
            ValidateIdentityDocument();
        }
    }
}
