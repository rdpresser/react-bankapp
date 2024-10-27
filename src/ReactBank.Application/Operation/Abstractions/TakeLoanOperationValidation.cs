using FluentValidation;
using ReactBank.Application.Commons.Bases.Validations;
using ReactBank.Application.Operation.Commands.TakeLoanOperationCommand;

namespace ReactBank.Application.Operation.Abstractions
{
    public class TakeLoanOperationValidation : BaseValidation<TakeLoanOperationCommand>
    {
        public void ValidateAccountId()
        {
            RuleFor(command => command.AccountId)
                .NotEmpty().WithMessage("Account ID is required.");
        }

        public void ValidateAmount()
        {
            RuleFor(command => command.Amount)
                .NotEmpty().WithMessage("Amount is required.")
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");
        }
    }
}
