using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recommendations;

namespace RecommandationsApi.Controllers
{
    [Route("api/[controller]")]
    public class UserRecController : Controller
    {
        // GET api/UserRec/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string AccountKey = "87c68aa99a23478fbf137408798b9897";
            string BaseUri = "https://westus.api.cognitive.microsoft.com/recommendations/v4.0";
            string modelId = "a5d3b654-d676-4390-a32b-b216dacacf29";
            long buildId = 1565379;

            RecommendationsApiWrapper recommender = new RecommendationsApiWrapper(AccountKey, BaseUri);

            return recommender.GetUserRecommendations(modelId, buildId, id.ToString(), 5);
        }
    }
}
