using Microsoft.AspNetCore.Mvc;
using ReactBank.Application.Loan.Abstractions;
using ReactBank.Application.Loan.DataContracts;

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
            var result = await _loanAppService.GetAllAsync();
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
        public async Task<ActionResult<LoanDataResponse>> Get(Guid id)
        {
            var result = await _loanAppService.GetByIdAsync(id);
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
