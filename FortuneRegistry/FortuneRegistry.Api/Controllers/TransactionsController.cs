using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public TransactionsController(TransactionsService transactionsService, IMapper mapper)
        {
            _transactionsService = transactionsService;
            _mapper = mapper;
        }

        [HttpGet("incomes")]
        public IEnumerable<TransactionResponse> GetIncomes(int offset = 0, int limit = 25)
        {
            return _transactionsService.GetIncomes().Select(x => _mapper.Map<TransactionResponse>(x));
        }

        [HttpGet("expenses")]
        public IEnumerable<TransactionResponse> GetExpenses(int offset = 0, int limit = 25)
        {
            return _transactionsService.GetExpenses().Select(x => _mapper.Map<TransactionResponse>(x));
        }

        [HttpPost]
        public ActionResult AddTransaction(TransactionRequest transaction)
        {
            _transactionsService.Add(transaction);

            return CreatedAtAction(nameof(AddTransaction), transaction);
        }

        [HttpGet("currencies")]
        public IEnumerable<Currency> GetCurrencies()
        {
            return _transactionsService.GetCurrencies();
        }
    }
}