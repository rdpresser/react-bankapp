using Microsoft.AspNetCore.Mvc;
using ReactBank.Application.Operation.Abstractions;
using ReactBank.Application.Operation.DataContracts;

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
        public async Task<ActionResult> Deposit(MakeDepositOperationDataRequest makeDepositOperationDataRequest)
        {
            var result = await _operationAppService.MakeDeposit(makeDepositOperationDataRequest);
            if (result.IsSuccess && result.Value != null)
            {
                return CreatedAtAction(nameof(TransactionController.Get), "Transaction", new { id = result.Value.Id }, result.Value);
            }
            else if (result.IsNotFound)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("withdraw")]
        public async Task<ActionResult> Withdraw(MakeWithdrawOperationDataRequest makeWithdrawOperationDataRequest)
        {
            var result = await _operationAppService.MakeWithdrawal(makeWithdrawOperationDataRequest);
            if (result.IsSuccess && result.Value != null)
            {
                return CreatedAtAction(nameof(TransactionController.Get), "Transaction", new { id = result.Value.Id }, result.Value);
            }
            else if (result.IsNotFound)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("transfer")]
        public async Task<ActionResult> Transfer(MakeTransferOperationDataRequest makeTransferOperationDataRequest)
        {
            var result = await _operationAppService.MakeTransfer(makeTransferOperationDataRequest);
            if (result.IsSuccess && result.Value != null)
            {
                return CreatedAtAction(nameof(TransactionController.Get), "Transaction", new { id = result.Value.Id }, result.Value);
            }
            else if (result.IsNotFound)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        //[HttpPost("loan")]
        //public async Task<ActionResult> Loan(TakeLoanOperationDataRequest takeLoanOperationDataRequest)
        //{
        //    if (takeLoanOperationDataRequest.AccountId == Guid.Empty || takeLoanOperationDataRequest.Amount <= 0)
        //    {
        //        return BadRequest("Invalid account ID or amount.");
        //    }

        //    try
        //    {
        //        await _operationAppService.TakeLoan(takeLoanOperationDataRequest);
        //        return Ok("Loan successful.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}
    }
}
