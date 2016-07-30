using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RecommandationsApi.Controllers
{
    [Route("api/[controller]")]
    public class SessionRecController : Controller
    {
        // GET api/SessionRec/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
