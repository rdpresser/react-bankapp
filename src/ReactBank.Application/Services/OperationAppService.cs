using ReactBank.Application.DataContracts;
using ReactBank.Application.Interfaces;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Services
{
    public class OperationAppService : IOperationAppService
    {
        private bool disposedValue;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOperationService _operationService;

        public OperationAppService(IUnitOfWork unitOfWork, IOperationService operationService)
        {
            _unitOfWork = unitOfWork;
            _operationService = operationService ?? throw new ArgumentNullException(nameof(operationService), $"{nameof(operationService)} could not be null"); ;
        }

        public async Task MakeDeposit(MakeDepositOperationDataRequest makeDepositOperationDataRequest)
        {
            Guid accountId = makeDepositOperationDataRequest.AccountId;
            decimal amount = makeDepositOperationDataRequest.Amount;

            await _operationService.MakeDeposit(accountId, amount);
            await _unitOfWork.CommitAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
