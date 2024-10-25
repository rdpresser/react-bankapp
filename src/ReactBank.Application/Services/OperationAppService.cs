using ReactBank.Application.DataContracts;
using ReactBank.Application.Interfaces;
using ReactBank.Domain.Interfaces.Repositores;
using ReactBank.Domain.Interfaces.Services;

namespace ReactBank.Application.Services
{
    public class OperationAppService : IOperationAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOperationService _operationService;

        public OperationAppService(IUnitOfWork unitOfWork, IOperationService operationService)
        {
            _unitOfWork = unitOfWork;
            _operationService = operationService ?? throw new ArgumentNullException(nameof(operationService), $"{nameof(operationService)} could not be null"); ;
        }

        public async Task MakeDeposit(MakeDepositOperationDataRequest makeDepositOperationDataRequest)
        {
            (Guid accountId, decimal amount) = (makeDepositOperationDataRequest.AccountId, makeDepositOperationDataRequest.Amount);

            await _operationService.MakeDeposit(accountId, amount);
            await _unitOfWork.CommitAsync();
        }

        public async Task MakeTransfer(MakeTransferOperationDataRequest makeTransferOperationDataRequest)
        {
            (Guid sourceAccountId, Guid destinationAccountId, decimal amount) =
                (makeTransferOperationDataRequest.SourceAccountId, makeTransferOperationDataRequest.DestinationAccountId, makeTransferOperationDataRequest.Amount);

            await _operationService.MakeTransfer(sourceAccountId, destinationAccountId, amount);
            await _unitOfWork.CommitAsync();
        }

        public async Task MakeWithdrawal(MakeWithdrawOperationDataRequest makeWithdrawOperationDataRequest)
        {
            (Guid accountId, decimal amount) = (makeWithdrawOperationDataRequest.AccountId, makeWithdrawOperationDataRequest.Amount);

            await _operationService.MakeWithdrawal(accountId, amount);
            await _unitOfWork.CommitAsync();
        }

        public async Task TakeLoan(TakeLoanOperationDataRequest takeLoanOperationDataRequest)
        {
            (Guid accountId, decimal amount, DateTime startDate, DateTime endDate, decimal interestRate) =
                (takeLoanOperationDataRequest.AccountId, takeLoanOperationDataRequest.Amount,
                takeLoanOperationDataRequest.StartDate, takeLoanOperationDataRequest.EndDate, takeLoanOperationDataRequest.InterestRate);

            await _operationService.TakeLoan(accountId, amount, startDate, endDate, interestRate);
            await _unitOfWork.CommitAsync();
        }
    }
}
