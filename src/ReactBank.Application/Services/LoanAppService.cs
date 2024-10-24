using Microsoft.EntityFrameworkCore;
using ReactBank.Application.DataContracts;
using ReactBank.Application.Interfaces;
using ReactBank.Application.Services.Base;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services;
using ReactBank.Domain.Models;

namespace ReactBank.Application.Services
{
    public class LoanAppService : BaseAppDataContractDomainService<LoanDataRequest, LoanDataResponse, Loan>, ILoanAppService
    {
        private readonly ILoanService _loanService;

        public LoanAppService(IUnitOfWork unitOfWork, ILoanService loanService)
            : base(unitOfWork, loanService)
        {
            _loanService = loanService ?? throw new ArgumentNullException(nameof(loanService), $"{nameof(loanService)} could not be null");
        }

        public override async Task<IEnumerable<LoanDataResponse>> GetAllAsync()
        {
            var list = await BaseService.GetAllNoTracking().ToListAsync();
            return list.Select(x => new LoanDataResponse
            {
                Amount = x.Amount,
                AccountId = x.AccountId,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                InterestRate = x.InterestRate,
                Id = x.Id
            });
        }

        public override Loan MapDataRequestToDomainEntity(LoanDataRequest dataContract)
        {
            return new Loan
            {
                Amount = dataContract.Amount,
                AccountId = dataContract.AccountId,
                StartDate = dataContract.StartDate,
                EndDate = dataContract.EndDate,
                InterestRate = dataContract.InterestRate
            };
        }

        public override LoanDataResponse MapDomainEntityToDataResponse(Loan domainEntity)
        {
            return new LoanDataResponse
            {
                Amount = domainEntity.Amount,
                AccountId = domainEntity.AccountId,
                StartDate = domainEntity.StartDate,
                EndDate = domainEntity.EndDate,
                InterestRate = domainEntity.InterestRate,
                Id = domainEntity.Id
            };
        }
    }
}
