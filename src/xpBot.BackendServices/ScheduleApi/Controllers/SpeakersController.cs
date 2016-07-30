using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ScheduleApi.Controllers
{
    [Route("api/[controller]")]
    public class SpeakersController : Controller
    {
        private Models.ScheduleContext _dbContext;
        public SpeakersController(Models.ScheduleContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/speakers
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sessions = await _dbContext.Speakers
                .Include(s => s.SessionSpeakers)
                .OrderBy(s => s.LastName)
                .ToListAsync();

            return Json(sessions);
        }

        // GET api/speakers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var session = await _dbContext.Speakers
                .Include(s => s.SessionSpeakers)
                .FirstOrDefaultAsync(s => s.Id == id);

            if(session == null)
            {
                return new NotFoundResult();
            }

            return Json(session);
        }
    }
}
