using Microsoft.AspNetCore.Mvc;
using ReactBank.Application.DataContracts;
using ReactBank.Application.Interfaces;

namespace ReactBankApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationAppService _operationAppService;

        public OperationController(IOperationAppService operationAppService)
        {
            _operationAppService = operationAppService ?? throw new ArgumentNullException(nameof(operationAppService), $"{nameof(operationAppService)} could not be null"); ; ;
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(MakeDepositOperationDataRequest makeDepositOperationDataRequest)
        {
            if (makeDepositOperationDataRequest.AccountId == Guid.Empty || makeDepositOperationDataRequest.Amount <= 0)
            {
                return BadRequest("Invalid account ID or amount.");
            }

            try
            {
                await _operationAppService.MakeDeposit(makeDepositOperationDataRequest);
                return Ok("Deposit successful.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(MakeWithdrawOperationDataRequest makeWithdrawOperationDataRequest)
        {
            if (makeWithdrawOperationDataRequest.AccountId == Guid.Empty || makeWithdrawOperationDataRequest.Amount <= 0)
            {
                return BadRequest("Invalid account ID or amount.");
            }

            try
            {
                await _operationAppService.MakeWithdrawal(makeWithdrawOperationDataRequest);
                return Ok("Withdrawal successful.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer(MakeTransferOperationDataRequest makeTransferOperationDataRequest)
        {
            if (makeTransferOperationDataRequest.SourceAccountId == Guid.Empty ||
                makeTransferOperationDataRequest.DestinationAccountId == Guid.Empty ||
                makeTransferOperationDataRequest.Amount <= 0)
            {
                return BadRequest("Invalid source account ID, destination account ID, or amount.");
            }

            if (makeTransferOperationDataRequest.SourceAccountId == makeTransferOperationDataRequest.DestinationAccountId)
            {
                return BadRequest("Source account ID and destination account ID shouldn't be the same.");
            }

            try
            {
                await _operationAppService.MakeTransfer(makeTransferOperationDataRequest);
                return Ok("Transfer successful.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("loan")]
        public async Task<IActionResult> Loan(TakeLoanOperationDataRequest takeLoanOperationDataRequest)
        {
            if (takeLoanOperationDataRequest.AccountId == Guid.Empty || takeLoanOperationDataRequest.Amount <= 0)
            {
                return BadRequest("Invalid account ID or amount.");
            }

            try
            {
                await _operationAppService.TakeLoan(takeLoanOperationDataRequest);
                return Ok("Loan successful.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
