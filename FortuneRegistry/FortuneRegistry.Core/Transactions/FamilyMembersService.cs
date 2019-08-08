using System;
using System.Collections.Generic;
using System.Text;
using FortuneRegistry.Persistence;
using FortuneRegistry.Shared.Models;

namespace FortuneRegistry.Core.Transactions
{
    public class FamilyMembersService
    {
        private readonly FamilyMembersRepository _familyMembersRepository;

        public FamilyMembersService(FamilyMembersRepository familyMembersRepository)
        {
            _familyMembersRepository = familyMembersRepository;
        }

        public IEnumerable<FamilyMember> GetAll()
        {
            return _familyMembersRepository.GetAll();
        }
    }
}
