using Microsoft.EntityFrameworkCore;
using ReactBank.Application.DataContracts;
using ReactBank.Application.Interfaces;
using ReactBank.Application.Services.Base;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services;
using ReactBank.Domain.Models;

namespace ReactBank.Application.Services
{
    public class TransactionAppService : BaseAppDataContractDomainService<TransactionDataRequest, TransactionDataResponse, Transaction>, ITransactionAppService
    {
        private readonly ITransactionService _transactionService;

        public TransactionAppService(IUnitOfWork unitOfWork, ITransactionService transactionService)
            : base(unitOfWork, transactionService)
        {
            _transactionService = transactionService ?? throw new ArgumentNullException(nameof(transactionService), $"{nameof(transactionService)} could not be null");
        }

        public override async Task<IEnumerable<TransactionDataResponse>> GetAllAsync()
        {
            var list = await BaseService.GetAllNoTracking()
                .OrderByDescending(x => x.DateTime)
                .ToListAsync();
            return list.Select(x => MapDomainEntityToDataResponse(x));
        }

        public override Transaction MapDataRequestToDomainEntity(TransactionDataRequest dataContract)
        {
            return new Transaction
            {
                Amount = dataContract.Amount,
                Currency = dataContract.Currency,
                DateTime = dataContract.DateTime,
                DestinationAccountId = dataContract.DestinationAccountId,
                SourceAccountId = dataContract.SourceAccountId,
                TransactionType = dataContract.TransactionType
            };
        }

        public override TransactionDataResponse MapDomainEntityToDataResponse(Transaction domainEntity)
        {
            return new TransactionDataResponse
            {
                Amount = domainEntity.Amount,
                Currency = domainEntity.Currency,
                DateTime = domainEntity.DateTime.ToString("MMMM dd, yyyy HH:mm"),
                DestinationAccount = $"{domainEntity.DestinationAccount.Customer.Name} - {domainEntity.DestinationAccountId}",
                SourceAccount = $"{domainEntity.SourceAccount.Customer.Name} - {domainEntity.SourceAccountId}",
                TransactionType = domainEntity.TransactionType,
                Id = domainEntity.Id
            };
        }
    }
}
