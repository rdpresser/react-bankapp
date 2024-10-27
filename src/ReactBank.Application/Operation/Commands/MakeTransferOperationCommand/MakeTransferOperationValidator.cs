using ReactBank.Application.Commons.Bases.Interfaces.Validations;
using ReactBank.Application.Operation.Abstractions;

namespace ReactBank.Application.Operation.Commands.MakeTransferOperationCommand
{
    public class MakeTransferOperationValidator : MakeTransferOperationValidation, IBaseValidation<MakeTransferOperationCommand>
    {
        public MakeTransferOperationValidator()
        {
            ValidateSourceAccountId();
            ValidateDestinationAccountId();
            ValidateAmount();
            ValidateSourceAndDestinationAccounts();
        }
    }
}
