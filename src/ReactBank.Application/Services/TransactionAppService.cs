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
            var list = await BaseService.GetAllNoTracking().ToListAsync();
            return list.Select(x => new TransactionDataResponse
            {
                Amount = x.Amount,
                Currency = x.Currency,
                DateTime = x.DateTime,
                DestinationAccountId = x.DestinationAccountId,
                SourceAccountId = x.SourceAccountId,
                TransactionType = x.TransactionType,
                Id = x.Id
            });
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
                DateTime = domainEntity.DateTime,
                DestinationAccountId = domainEntity.DestinationAccountId,
                SourceAccountId = domainEntity.SourceAccountId,
                TransactionType = domainEntity.TransactionType,
                Id = domainEntity.Id
            };
        }

        //public async Task<bool> TransferAsync(TransactionDataRequest dataRequest)
        //{
        //    using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        //    {
        //        var sourceAccount = await _unitOfWork.AccountRepository.GetByIdAsync(dataRequest.AccountId);
        //        var targetAccount = await _unitOfWork.AccountRepository.GetByIdAsync(dataRequest.TargetAccountId);

        //        if (sourceAccount == null || targetAccount == null)
        //        {
        //            return false;
        //        }

        //        sourceAccount.Balance -= dataRequest.Amount;
        //        targetAccount.Balance += dataRequest.Amount;

        //        await _unitOfWork.AccountRepository.UpdateAsync(sourceAccount);
        //        await _unitOfWork.AccountRepository.UpdateAsync(targetAccount);

        //        var transaction = new Transaction
        //        {
        //            AccountId = sourceAccount.Id,
        //            Amount = dataRequest.Amount,
        //            TransactionDate = DateTime.Now,
        //            TransactionType = TransactionType.Transfer
        //        };

        //        await _unitOfWork.TransactionRepository.AddAsync(transaction);

        //        if (await CommitAsync())
        //        {
        //            scope.Complete();
        //            return true;
        //        }

        //        return false;
        //    }
        //}
    }
}
