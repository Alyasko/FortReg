using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FortuneRegistry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new List<string>()
            {
                "apple",
                "orange",
                "lemon"
            };
        }
    }
}