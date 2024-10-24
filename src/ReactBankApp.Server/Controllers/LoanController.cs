using Microsoft.AspNetCore.Mvc;
using ReactBank.Application.DataContracts;
using ReactBank.Application.Interfaces;

namespace ReactBankApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanAppService _loanAppService;

        public LoanController(ILoanAppService loanAppService)
        {
            _loanAppService = loanAppService ?? throw new ArgumentNullException(nameof(loanAppService), $"{nameof(loanAppService)} could not be null");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanDataResponse>>> Get()
        {
            var loans = await _loanAppService.GetAllAsync();
            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDataResponse>> Get(Guid id)
        {
            var loan = await _loanAppService.GetByIdAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);
        }

        [HttpPost]
        public async Task<ActionResult<LoanDataResponse>> Post([FromBody] LoanDataRequest loanDataRequest)
        {
            var loan = await _loanAppService.CreateAsync(loanDataRequest);
            return CreatedAtAction(nameof(Get), new { id = loan.Id }, loan);
        }
    }
}
