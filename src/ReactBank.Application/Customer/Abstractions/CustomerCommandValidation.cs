using FluentValidation;
using ReactBank.Application.Commons.Bases.Validations;
using ReactBank.Application.Customer.Commands.CreateCustomerCommand;

namespace ReactBank.Application.Customer.Abstractions
{
    public class CustomerCommandValidation : BaseValidation<CreateCustomerCommand>
    {
        public void ValidateName()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
        }

        public void ValidateEmail()
        {
            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }

        public void ValidatePhone()
        {
            RuleFor(command => command.Phone)
                .NotEmpty().WithMessage("Phone is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");
        }

        public void ValidateStreetAddress()
        {
            RuleFor(command => command.StreetAddress)
                .NotEmpty().WithMessage("Street address is required.")
                .MaximumLength(200).WithMessage("Street address must not exceed 200 characters.");
        }

        public void ValidateCity()
        {
            RuleFor(command => command.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(100).WithMessage("City must not exceed 100 characters.");
        }

        public void ValidateState()
        {
            RuleFor(command => command.State)
                .NotEmpty().WithMessage("State is required.")
                .MaximumLength(100).WithMessage("State must not exceed 100 characters.");
        }

        public void ValidateZipCode()
        {
            RuleFor(command => command.ZipCode)
                .NotEmpty().WithMessage("Zip code is required.")
                .Matches(@"^\d{5}(-\d{4})?$").WithMessage("Invalid zip code format.");
        }

        public void ValidateDateOfBirth()
        {
            RuleFor(command => command.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
                .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.");
        }

        public void ValidateIdentityDocument()
        {
            RuleFor(command => command.IdentityDocument)
                .NotEmpty().WithMessage("Identity document is required.")
                .MaximumLength(50).WithMessage("Identity document must not exceed 50 characters.");
        }
    }
}
