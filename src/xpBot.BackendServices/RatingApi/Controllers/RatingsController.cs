using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TextAnalytics;

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
            string AccountKey = "a59b8894fe7a48ef8bef36865c8e561c";
            string BaseUri = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0";

            TextAnalyticsApiWrapper recommender = new TextAnalyticsApiWrapper(AccountKey, BaseUri);

            int value = recommender.GetSentiment(rating.SentimentalText);

            Models.Rating result = new Models.Rating() { UserId = rating.UserId, SessionId = rating.SessionId, Notation = value };

            _dbContext.Ratings.Add(result);
            await _dbContext.SaveChangesAsync();
            return new CreatedResult(string.Empty, null);
        }
    }
}
