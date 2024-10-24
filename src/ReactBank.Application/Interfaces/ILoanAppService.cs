using ReactBank.Application.DataContracts;
using ReactBank.Application.Interfaces.Base;

namespace ReactBank.Application.Interfaces
{
    public interface ILoanAppService : IBaseAppService<LoanDataRequest, LoanDataResponse>
    {

    }
}
