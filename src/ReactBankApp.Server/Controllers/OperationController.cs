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
        public IActionResult Withdraw()
        {
            return Ok();
        }

        [HttpPost("transfer")]
        public IActionResult Transfer()
        {
            return Ok();
        }

        [HttpPost("loan")]
        public IActionResult Loan()
        {
            return Ok();
        }
    }
}
