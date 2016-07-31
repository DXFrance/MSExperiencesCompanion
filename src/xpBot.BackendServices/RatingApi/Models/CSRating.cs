using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApi.Models
{
    public class CSRating
    {
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public string SentimentalText { get; set; }
    }
}
