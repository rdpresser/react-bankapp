using Microsoft.AspNetCore.Mvc;
using ReactBank.Application.DataContracts;
using ReactBank.Application.Interfaces;

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
            var transactions = await _transactionAppService.GetAllAsync();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDataResponse>> Get(Guid id)
        {
            var transaction = await _transactionAppService.GetByIdAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult<TransactionDataResponse>> Post([FromBody] TransactionDataRequest transactionDataRequest)
        {
            var transaction = await _transactionAppService.CreateAsync(transactionDataRequest);
            return CreatedAtAction(nameof(Get), new { id = transaction.Id }, transaction);
        }
    }
}
