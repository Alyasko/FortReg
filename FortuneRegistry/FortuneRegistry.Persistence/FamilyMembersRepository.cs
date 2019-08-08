using System;
using System.Collections.Generic;
using System.Text;
using FortuneRegistry.Shared.Models;

namespace FortuneRegistry.Persistence
{
    public class FamilyMembersRepository : BaseRepository<FamilyMember>
    {
        protected override string CollectionName { get; set; } = "family_members";
    }
}
