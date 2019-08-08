using System.Collections.Generic;
using FortuneRegistry.Core.Transactions;
using FortuneRegistry.Shared.Models;
using FortuneRegistry.Shared.Models.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace FortuneRegistry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionsService _transactionsService;

        public TransactionsController(TransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [HttpGet("incomes")]
        public IEnumerable<Transaction> GetIncomes(int offset = 0, int limit = 25)
        {
            return _transactionsService.GetIncomes();
        }

        [HttpPost("incomes")]
        public ActionResult AddIncome(Transaction transaction)
        {
            _transactionsService.Add(transaction);

            return CreatedAtAction(nameof(AddIncome), transaction);
        }

        [HttpGet("expenses")]
        public IEnumerable<Transaction> GetExpenses(int offset = 0, int limit = 25)
        {
            return _transactionsService.GetExpenses();
        }

        [HttpGet("currencies")]
        public IEnumerable<Currency> GetCurrencies()
        {
            return _transactionsService.GetCurrencies();
        }
    }
}