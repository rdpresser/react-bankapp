using Microsoft.AspNetCore.Mvc;
using ReactBank.Application.DataContracts;
using ReactBank.Application.Interfaces;

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
            var customers = await _customerAppService.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDataResponse>> Get(Guid id)
        {
            var customer = await _customerAppService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDataResponse>> Post([FromBody] CustomerDataRequest customerDataRequest)
        {
            var customer = await _customerAppService.CreateAsync(customerDataRequest);
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
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
