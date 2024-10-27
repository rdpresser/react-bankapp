using FluentValidation;
using ReactBank.Application.Commons.Bases.Validations;
using ReactBank.Application.Operation.Commands.MakeDepositOperationCommand;

namespace ReactBank.Application.Operation.Abstractions
{
    public class MakeDepositOperationValidation : BaseValidation<MakeDepositOperationCommand>
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
