using Microsoft.AspNetCore.Mvc;
using ReactBank.Application.DataContracts;
using ReactBank.Application.Interfaces;

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
            var accounts = await _accountAppService.GetAllAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDataResponse>> Get(Guid id)
        {
            var account = await _accountAppService.GetByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpPost]
        public async Task<ActionResult<AccountDataResponse>> Post([FromBody] AccountDataRequest accountDataRequest)
        {
            var account = await _accountAppService.CreateAsync(accountDataRequest);
            return CreatedAtAction(nameof(Get), new { id = account.Id }, account);
        }
    }
}
