using FluentValidation;
using ReactBank.Application.Commons.Bases.Validations;
using ReactBank.Application.Loan.Commands.CreateLoanCommand;

namespace ReactBank.Application.Loan.Abstractions
{
    public class LoanCommandValidation : BaseValidation<CreateLoanCommand>
    {
        public void ValidateAmount()
        {
            RuleFor(command => command.Amount)
                .NotEmpty().WithMessage("Amount is required.")
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");
        }

        public void ValidateInterestRate()
        {
            RuleFor(command => command.InterestRate)
                .NotEmpty().WithMessage("Interest rate is required.")
                .GreaterThan(0).WithMessage("Interest rate must be greater than 0.");
        }

        public void ValidateStartDate()
        {
            RuleFor(command => command.StartDate)
                .NotEmpty().WithMessage("Start date is required.")
                .LessThan(command => command.EndDate).WithMessage("Start date must be less than end date.");
        }

        public void ValidateEndDate()
        {
            RuleFor(command => command.EndDate)
                .NotEmpty().WithMessage("End date is required.")
                .GreaterThan(command => command.StartDate).WithMessage("End date must be greater than start date.");
        }

        public void ValidateAccountId()
        {
            RuleFor(command => command.AccountId)
                .NotEmpty().WithMessage("Account id is required.");
        }
    }
}
