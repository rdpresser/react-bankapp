using ReactBank.Application.Commons.Bases.Interfaces.Validations;
using ReactBank.Application.Operation.Abstractions;

namespace ReactBank.Application.Operation.Commands.TakeLoanOperationCommand
{
    public class TakeLoanOperationValidator : TakeLoanOperationValidation, IBaseValidation<TakeLoanOperationCommand>
    {
        public TakeLoanOperationValidator()
        {
            ValidateAccountId();
            ValidateAmount();
        }
    }
}
