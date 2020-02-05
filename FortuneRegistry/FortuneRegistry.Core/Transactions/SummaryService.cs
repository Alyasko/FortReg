using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FortuneRegistry.Persistence;
using FortuneRegistry.Shared.Models.Summary;
using FortuneRegistry.Shared.Models.Transactions;

namespace FortuneRegistry.Core.Transactions
{
    public class SummaryService
    {
        private readonly CategoriesRepository _categoriesRepository;
        private readonly TransactionsRepository _transactionsRepository;
        private readonly PlansRepository _plansRepository;

        public SummaryService(CategoriesRepository categoriesRepository, TransactionsRepository transactionsRepository, PlansRepository plansRepository)
        {
            _categoriesRepository = categoriesRepository;
            _transactionsRepository = transactionsRepository;
            _plansRepository = plansRepository;
        }

        public async Task<MonthlySummary> CalculateMonthlySummaryAsync(DateTime? month, CancellationToken cancellationToken = default)
        {
            var selectedMonth = month ?? DateTime.UtcNow;

            var summary = new MonthlySummary()
            {
                AllExpenses = await GetMonthlyExpensesAsync(selectedMonth, cancellationToken).ConfigureAwait(false),
                AllIncomes = await GetMonthlyIncomesAsync(selectedMonth, cancellationToken).ConfigureAwait(false)
            };

            return summary;
        }

        private async Task<IEnumerable<CategorySummary>> GetMonthlyExpensesAsync(DateTime month, CancellationToken cancellationToken = default)
        {
            var expenses = new List<CategorySummary>();

            var plannedExpenses = await _plansRepository.GetExpensesPlanAsync(month).ConfigureAwait(false);
            var transactions = await _transactionsRepository.GetExpensesAsync(month, cancellationToken).ConfigureAwait(false);

            foreach (var plan in plannedExpenses)
            {
                expenses.Add(new CategorySummary()
                {
                    Plan = plan,
                    Type = TransactionType.Expense,
                    Transactions = transactions
                });
            }

            return expenses;
        }

        private async Task<IEnumerable<CategorySummary>> GetMonthlyIncomesAsync(DateTime month, CancellationToken cancellationToken = default)
        {
            var incomes = new List<CategorySummary>();

            var plannedIncomes = await _plansRepository.GetIncomesPlanAsync(month, cancellationToken).ConfigureAwait(false);
            var transactions = await _transactionsRepository.GetIncomesAsync(month, cancellationToken).ConfigureAwait(false);

            foreach (var plan in plannedIncomes)
            {
                incomes.Add(new CategorySummary()
                {
                    Plan = plan,
                    Type = TransactionType.Income,
                    Transactions = transactions/*.Where(x => x.Category.Id == plan.Id)*/
                });
            }

            return incomes;
        }

        public async Task AddPlanAsync(Plan plan, CancellationToken cancellationToken = default)
        {
            if(plan.Created == null)
                plan.Created = DateTime.UtcNow;                

            await _plansRepository.SaveAsync(plan, cancellationToken).ConfigureAwait(false);
        }
    }
}
