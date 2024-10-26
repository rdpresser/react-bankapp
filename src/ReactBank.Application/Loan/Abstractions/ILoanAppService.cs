using ReactBank.Application.Commons.Bases.Interfaces.Services;
using ReactBank.Application.Loan.DataContracts;

namespace ReactBank.Application.Loan.Abstractions
{
    public interface ILoanAppService : IBaseAppService<LoanDataRequest, LoanDataResponse>
    {

    }
}
