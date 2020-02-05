using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<FamilyMember>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _familyMembersRepository.QueryAllAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
