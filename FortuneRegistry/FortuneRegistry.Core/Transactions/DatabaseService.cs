using System;
using System.Collections.Generic;
using System.Text;
using FortuneRegistry.Persistence;
using FortuneRegistry.Shared.Models;

namespace FortuneRegistry.Core.Transactions
{
    public class DatabaseService
    {
        private readonly FamilyMembersRepository _familyMembersRepository;
        private readonly CategoriesRepository _categoriesRepository;
        private readonly CurrenciesRepository _currenciesRepository;

        public DatabaseService(FamilyMembersRepository familyMembersRepository, CategoriesRepository categoriesRepository, CurrenciesRepository currenciesRepository)
        {
            _familyMembersRepository = familyMembersRepository;
            _categoriesRepository = categoriesRepository;
            _currenciesRepository = currenciesRepository;
        }

        public void SeedRandom()
        {
            var members = new List<FamilyMember>()
            {
                new FamilyMember("Bob", "Smith"),
                new FamilyMember("Helen", "Smith"),
            };
            _familyMembersRepository.Add(members);

            var categories = new List<Category>()
            {
                new Category("Cat 1"),
                new Category("Cat 2"),
                new Category("Cat 3"),
            };
            _categoriesRepository.Add(categories);

            var currencies = new List<Currency>()
            {
                new Currency("EUR"),
                new Currency("USD")
            };
            _currenciesRepository.Add(currencies);
        }

        public bool DeleteDatabase()
        {
            return _categoriesRepository.DeleteDatabaseFile();
        }
    }
}
