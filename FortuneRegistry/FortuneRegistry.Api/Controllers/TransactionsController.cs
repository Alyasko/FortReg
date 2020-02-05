using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FortuneRegistry.Core.Transactions;
using FortuneRegistry.Shared.Models;
using FortuneRegistry.Shared.Models.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace FortuneRegistry.Api.Controllers
{
    [Route("api/[controller]/")]
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
        public async Task<IEnumerable<TransactionResponse>> GetIncomesAsync(int offset = 0, int limit = 25, CancellationToken cancellationToken = default)
        {
            return (await _transactionsService.GetIncomesAsync(cancellationToken).ConfigureAwait(false)).Select(x => _mapper.Map<TransactionResponse>(x));
        }

        [HttpGet("expenses")]
        public async Task<IEnumerable<TransactionResponse>> GetExpensesAsync(int offset = 0, int limit = 25, CancellationToken cancellationToken = default)
        {
            return (await _transactionsService.GetExpensesAsync(cancellationToken).ConfigureAwait(false)).Select(x => _mapper.Map<TransactionResponse>(x));
        }

        [HttpPost]
        public async Task<ActionResult> AddTransaction(TransactionRequest transaction, CancellationToken cancellationToken = default)
        {
            await _transactionsService.AddAsync(transaction, cancellationToken).ConfigureAwait(false);

            return CreatedAtAction(nameof(AddTransaction), transaction);
        }

        [HttpGet("currencies")]
        public async Task<IEnumerable<Currency>> GetCurrencies(CancellationToken cancellationToken = default)
        {
            return await _transactionsService.GetCurrenciesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}