using ReactBank.Application.Commons.Bases.Interfaces.Validations;
using ReactBank.Application.Operation.Abstractions;

namespace ReactBank.Application.Operation.Commands.MakeDepositOperationCommand
{
    public class MakeDepositOperationValidator : MakeDepositOperationValidation, IBaseValidation<MakeDepositOperationCommand>
    {
        public MakeDepositOperationValidator()
        {
            ValidateAccountId();
            ValidateAmount();
        }
    }
}
