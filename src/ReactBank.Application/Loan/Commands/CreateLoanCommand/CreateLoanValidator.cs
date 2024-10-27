using ReactBank.Application.Commons.Bases.Interfaces.Validations;
using ReactBank.Application.Loan.Abstractions;

namespace ReactBank.Application.Loan.Commands.CreateLoanCommand
{
    public class CreateLoanValidator : LoanCommandValidation, IBaseValidation<CreateLoanCommand>
    {
        public CreateLoanValidator()
        {
            ValidateAmount();
            ValidateInterestRate();
            ValidateStartDate();
            ValidateEndDate();
            ValidateAccountId();
        }
    }
}
