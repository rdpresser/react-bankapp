using Microsoft.EntityFrameworkCore;
using ReactBank.Application.DataContracts;
using ReactBank.Application.Interfaces;
using ReactBank.Application.Services.Base;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services;
using ReactBank.Domain.Models;

namespace ReactBank.Application.Services
{
    public class AccountAppService : BaseAppDataContractDomainService<AccountDataRequest, AccountDataResponse, Account>, IAccountAppService
    {
        private readonly IAccountService _accountService;

        public AccountAppService(IUnitOfWork unitOfWork, IAccountService accountService)
            : base(unitOfWork, accountService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService), $"{nameof(accountService)} could not be null");
        }

        public override async Task<IEnumerable<AccountDataResponse>> GetAllAsync()
        {
            var list = await BaseService.GetAllNoTracking()
                .OrderBy(x => x.AccountNumber)
                .ToListAsync();
            return list.Select(x => MapDomainEntityToDataResponse(x));
        }

        public override Account MapDataRequestToDomainEntity(AccountDataRequest dataContract)
        {
            return new Account
            {
                AccountNumber = dataContract.AccountNumber,
                Balance = dataContract.Balance,
                CustomerId = dataContract.CustomerId,
                Currency = dataContract.Currency,
                AccountType = dataContract.AccountType,
            };
        }

        public override AccountDataResponse MapDomainEntityToDataResponse(Account domainEntity)
        {
            return new AccountDataResponse
            {
                AccountNumber = domainEntity.AccountNumber,
                Balance = domainEntity.Balance,
                Currency = domainEntity.Currency,
                AccountType = domainEntity.AccountType,
                Id = domainEntity.Id
            };
        }
    }
}
