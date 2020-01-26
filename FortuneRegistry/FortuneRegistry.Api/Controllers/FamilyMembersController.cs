using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FortuneRegistry.Persistence;
using FortuneRegistry.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FortuneRegistry.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class FamilyMembersController : ControllerBase
    {
        private readonly FamilyMembersRepository _familyMembersRepository;

        public FamilyMembersController(FamilyMembersRepository familyMembersRepository)
        {
            _familyMembersRepository = familyMembersRepository;
        }

        [HttpGet("query")]
        public async Task<IEnumerable<FamilyMember>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _familyMembersRepository.QueryAllAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
