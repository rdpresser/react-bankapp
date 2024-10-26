//using Microsoft.AspNetCore.Mvc;
//using ReactBank.Application.DataContracts.Loan;
//using ReactBank.Application.Interfaces.Services;

//namespace ReactBankApp.Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LoanController : ControllerBase
//    {
//        private readonly ILoanAppService _loanAppService;

//        public LoanController(ILoanAppService loanAppService)
//        {
//            _loanAppService = loanAppService ?? throw new ArgumentNullException(nameof(loanAppService), $"{nameof(loanAppService)} could not be null");
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<LoanDataResponse>>> Get()
//        {
//            var loans = await _loanAppService.GetAllAsync();
//            return Ok(loans);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<LoanDataResponse>> Get(Guid id)
//        {
//            var loan = await _loanAppService.GetByIdAsync(id);
//            if (loan == null)
//            {
//                return NotFound();
//            }

//            return Ok(loan);
//        }
//    }
//}
