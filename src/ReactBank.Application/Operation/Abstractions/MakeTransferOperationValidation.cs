using FluentValidation;
using ReactBank.Application.Commons.Bases.Validations;
using ReactBank.Application.Operation.Commands.MakeTransferOperationCommand;

namespace ReactBank.Application.Operation.Abstractions
{
    public class MakeTransferOperationValidation : BaseValidation<MakeTransferOperationCommand>
    {
        public void ValidateSourceAccountId()
        {
            RuleFor(command => command.SourceAccountId)
                .NotEmpty().WithMessage("Source Account ID is required.");
        }

        public void ValidateDestinationAccountId()
        {
            RuleFor(command => command.DestinationAccountId)
                .NotEmpty().WithMessage("Destination Account ID is required.");
        }

        public void ValidateAmount()
        {
            RuleFor(command => command.Amount)
                .NotEmpty().WithMessage("Amount is required.")
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");
        }

        public void ValidateSourceAndDestinationAccounts()
        {
            RuleFor(command => new { command.SourceAccountId, command.DestinationAccountId })
                .Must(command => command.SourceAccountId != command.DestinationAccountId)
                .WithMessage("Source Account ID and Destination Account ID shouldn't be the same.");
        }
    }
}
