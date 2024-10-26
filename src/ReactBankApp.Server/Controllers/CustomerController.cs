using Microsoft.AspNetCore.Mvc;
using ReactBank.Application.Customer.Abstractions;
using ReactBank.Application.Customer.DataContracts;

namespace ReactBankApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService ?? throw new ArgumentNullException(nameof(customerAppService), $"{nameof(customerAppService)} could not be null");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDataResponse>>> Get()
        {
            var result = await _customerAppService.GetAllAsync();
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
        public async Task<ActionResult<CustomerDataResponse>> Get(Guid id)
        {
            var result = await _customerAppService.GetByIdAsync(id);
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

        [HttpPost]
        public async Task<ActionResult<CustomerDataResponse>> Post([FromBody] CustomerDataRequest customerDataRequest)
        {
            var result = await _customerAppService.CreateCustomerAsync(customerDataRequest);

            if (result.IsSuccess && result.Value != null)
            {
                return CreatedAtAction(nameof(Get), new { id = result.Value.Id }, result.Value);
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

        //TODO: For future versions
        //[HttpPut("{id}")]
        //public async Task<ActionResult<CustomerDataResponse>> Put(Guid id, [FromBody] CustomerDataRequest customerDataRequest)
        //{
        //    if (id != customerDataRequest.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var customer = await _customerAppService.UpdateAsync(customerDataRequest);
        //    return Ok(customer);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<CustomerDataResponse>> Delete(Guid id)
        //{
        //    var customer = await _customerAppService.GetByIdAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    await _customerAppService.DeleteAsync(id);
        //    return Ok(customer);
        //}
    }
}
