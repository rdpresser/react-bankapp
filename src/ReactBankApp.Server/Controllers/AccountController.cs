using Microsoft.AspNetCore.Mvc;
using ReactBank.Application.Account.Abstractions;
using ReactBank.Application.Account.DataContracts;

namespace ReactBankApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountAppService _accountAppService;
        public AccountController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService ?? throw new ArgumentNullException(nameof(accountAppService), $"{nameof(accountAppService)} could not be null");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDataResponse>>> Get()
        {
            var result = await _accountAppService.GetAllAsync();
            if (result.IsSuccess && result.Value != null)
            {
                return Ok(result.Value);
            }
            else if (result.IsSuccess && result.Value == null)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDataResponse>> Get(Guid id)
        {
            var result = await _accountAppService.GetByIdAsync(id);

            if (result.IsSuccess && result.Value != null)
            {
                return Ok(result.Value);
            }
            else if (result.IsSuccess && result.Value == null)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost]
        public async Task<ActionResult<AccountDataResponse>> Post([FromBody] AccountDataRequest accountDataRequest)
        {
            var result = await _accountAppService.CreateAccountAsync(accountDataRequest);

            if (result.IsSuccess && result.Value != null)
            {
                return CreatedAtAction(nameof(Get), new { id = result.Value.Id }, result.Value);
            }
            else if (result.IsSuccess && result.Value == null)
            {
                return NotFound();
            }
            else
            {
                //TODO: verify best way to return errors using problemdetails pattern
                return BadRequest(result.Errors);
            }
        }
    }
}
