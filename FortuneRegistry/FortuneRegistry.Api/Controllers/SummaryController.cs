using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Add(Plan plan)
        {
            _summaryService.AddPlan(plan);

            return Created(nameof(Add), plan);
        }

        [HttpGet("expenses")]
        public IEnumerable<CategorySummary> GetExpenses(DateTime? dateMonth)
        {
            return _summaryService.CalculateMonthlySummary(dateMonth).AllExpenses;
        }

        [HttpGet("incomes")]
        public IEnumerable<CategorySummary> GetIncomes(DateTime? dateMonth)
        {
            return _summaryService.CalculateMonthlySummary(dateMonth).AllIncomes;
        }
    }
}
