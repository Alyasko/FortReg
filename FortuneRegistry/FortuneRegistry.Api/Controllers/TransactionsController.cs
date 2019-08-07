﻿using System.Collections.Generic;
using FortuneRegistry.Shared.Models.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace FortuneRegistry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpGet("incomes")]
        public IEnumerable<string> GetIncomeTransactions(int offset = 0, int limit = 25)
        {
            return new List<string>()
            {
                "income1",
                "income2"
            };
        }

        [HttpPost("incomes")]
        public ActionResult AddIncomeTransaction(Transaction transaction)
        {
            return CreatedAtAction(nameof(AddIncomeTransaction), transaction);
        }

        [HttpGet("expenses")]
        public IEnumerable<string> GetExpensesTransactions(int offset = 0, int limit = 25)
        {
            return new List<string>()
            {
                "expense1",
                "expense2"
            };
        }
    }
}