using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RatingApi.Controllers
{
    [Route("api/[controller]")]
    public class RatingsController : Controller
    {
        private Models.RatingContext _dbContext;
        public RatingsController(Models.RatingContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Models.Rating>> Get()
        {
            return await _dbContext.Ratings.ToListAsync();
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Rating value)
        {
            _dbContext.Ratings.Add(value);
            await _dbContext.SaveChangesAsync();
            return new CreatedResult(string.Empty, null);
        }

        [HttpPost]
        [Route("cs")]
        public async Task<IActionResult> Post([FromBody]Models.CSRating rating)
        {
            // todo : benjat : rating.SentimentalText
            await _dbContext.SaveChangesAsync();
            return new CreatedResult(string.Empty, null);
        }
    }
}
