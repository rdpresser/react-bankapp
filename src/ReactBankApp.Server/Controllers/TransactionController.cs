﻿using Microsoft.AspNetCore.Mvc;
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
            //var transactions = await _transactionAppService.GetAllAsync();
            //return Ok(transactions);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDataResponse>> Get(Guid id)
        {
            //var transaction = await _transactionAppService.GetByIdAsync(id);
            //if (transaction == null)
            //{
            //    return NotFound();
            //}

            //return Ok(transaction);
            return Ok();
        }
    }
}
