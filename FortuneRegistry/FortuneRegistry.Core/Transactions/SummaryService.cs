using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public MonthlySummary CalculateMonthlySummary(DateTime? month)
        {
            var selectedMonth = month ?? DateTime.UtcNow;

            var summary = new MonthlySummary()
            {
                AllExpenses = GetMonthlyExpenses(selectedMonth),
                AllIncomes = GetMonthlyIncomes(selectedMonth)
            };

            return summary;
        }

        private IEnumerable<CategorySummary> GetMonthlyExpenses(DateTime month)
        {
            var expenses = new List<CategorySummary>();

            var plannedExpenses = _plansRepository.GetExpensesPlan(month);
            var transactions = _transactionsRepository.GetExpenses(month).ToArray();

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

        private IEnumerable<CategorySummary> GetMonthlyIncomes(DateTime month)
        {
            var incomes = new List<CategorySummary>();

            var plannedIncomes = _plansRepository.GetExpensesPlan(month);
            var transactions = _transactionsRepository.GetExpenses(month).ToArray();

            foreach (var plan in plannedIncomes)
            {
                incomes.Add(new CategorySummary()
                {
                    Plan = plan,
                    Type = TransactionType.Income,
                    Transactions = transactions
                });
            }

            return incomes;
        }
    }
}
