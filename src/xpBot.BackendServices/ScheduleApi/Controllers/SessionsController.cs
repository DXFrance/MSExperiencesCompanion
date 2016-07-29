using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ScheduleApi.Controllers
{
    [Route("api/[controller]")]
    public class SessionsController : Controller
    {
        private Models.ScheduleContext _dbContext;
        public SessionsController(Models.ScheduleContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/sessions
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sessions = await _dbContext.Sessions
                .Include(s => s.SessionSpeakers)
                    .ThenInclude(p => p.Speaker)
                .OrderBy(s => s.Code)
                .ToListAsync();

            return Json(sessions);
        }

        // GET api/sessions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var session = await _dbContext.Sessions
                .Include(s => s.SessionSpeakers)
                    .ThenInclude(p => p.Speaker)
                .FirstOrDefaultAsync(s => s.Id == id);

            if(session == null)
            {
                return new NotFoundResult();
            }

            return Json(session);
        }
    }
}
