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

        public DatabaseService(FamilyMembersRepository familyMembersRepository)
        {
            _familyMembersRepository = familyMembersRepository;
        }

        public void SeedRandom()
        {
            var members = new List<FamilyMember>()
            {
                new FamilyMember("Bob", "Smith"),
                new FamilyMember("Helen", "Smith"),
            };

            _familyMembersRepository.Add(members);
        }
    }
}
