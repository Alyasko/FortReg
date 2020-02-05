using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FortuneRegistry.Core.Transactions;
using FortuneRegistry.Shared.Models.Summary;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FortuneRegistry.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SummaryController : Controller
    {
        private readonly SummaryService _summaryService;

        public SummaryController(SummaryService summaryService)
        {
            _summaryService = summaryService;
        }

        [HttpPost()]
        public async Task<ActionResult> AddAsync(Plan plan, CancellationToken cancellationToken = default)
        {
            await _summaryService.AddPlanAsync(plan, cancellationToken).ConfigureAwait(false);

            return Created(nameof(AddAsync), plan);
        }

        [HttpGet("expenses")]
        public async Task<IEnumerable<CategorySummary>> GetExpensesAsync(DateTime? dateMonth, CancellationToken cancellationToken = default)
        {
            return (await _summaryService.CalculateMonthlySummaryAsync(dateMonth, cancellationToken).ConfigureAwait(false)).AllExpenses;
        }

        [HttpGet("incomes")]
        public async Task<IEnumerable<CategorySummary>> GetIncomesAsync(DateTime? dateMonth, CancellationToken cancellationToken = default)
        {
            return (await _summaryService.CalculateMonthlySummaryAsync(dateMonth, cancellationToken)).AllIncomes;
        }
    }
}
