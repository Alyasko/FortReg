using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FortuneRegistry.Core.Transactions;
using FortuneRegistry.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FortuneRegistry.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class CategoriesController : Controller
    {
        private readonly CategoriesService _categoriesService;

        public CategoriesController(CategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet("query")]
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoriesService.GetAllAsync().ConfigureAwait(false);
        }
    }
}
