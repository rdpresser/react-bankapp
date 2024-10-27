using Microsoft.AspNetCore.Mvc;
using ReactBank.Application.Transaction.Abstractions;
using ReactBank.Application.Transaction.DataContracts;

namespace ReactBankApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionAppService _transactionAppService;

        public TransactionController(ITransactionAppService transactionAppService)
        {
            _transactionAppService = transactionAppService ?? throw new ArgumentNullException(nameof(transactionAppService), $"{nameof(transactionAppService)} could not be null");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDataResponse>>> Get()
        {
            var result = await _transactionAppService.GetAllAsync();
            if (result.IsSuccess && result.Value != null)
            {
                return Ok(result.Value);
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

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDataResponse>> Get(Guid id)
        {
            var result = await _transactionAppService.GetByIdAsync(id);
            if (result.IsSuccess && result.Value != null)
            {
                return Ok(result.Value);
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
    }
}
