using ReactBank.Application.Commons.Bases.Interfaces.Validations;
using ReactBank.Application.Operation.Abstractions;

namespace ReactBank.Application.Operation.Commands.MakeWithdrawOperationCommand
{
    public class MakeWithdrawOperationValidator : MakeWithdrawOperationValidation, IBaseValidation<MakeWithdrawOperationCommand>
    {
        public MakeWithdrawOperationValidator()
        {
            ValidateAccountId();
            ValidateAmount();
        }
    }
}
