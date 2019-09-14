using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FortuneRegistry.Core.Transactions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FortuneRegistry.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : Controller
    {
        private readonly DatabaseService _serviceDb;

        public DatabaseController(DatabaseService serviceDb)
        {
            _serviceDb = serviceDb;
        }

        [HttpPost("seed")]
        public ActionResult Seed()
        {
            // TODO: add auth.
            _serviceDb.SeedRandom();

            return Accepted();
        }

        [HttpPost("delete")]
        public ActionResult Delete()
        {
            // TODO: add auth.
            if (_serviceDb.DeleteDatabase())
                return Accepted();

            return Conflict();
        }
    }
}
