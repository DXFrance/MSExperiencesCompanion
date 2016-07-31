using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApi.Models
{
    public class Rating
    {
        public int SessionId { get; set; }
        public int Notation { get; set; }
        public int UserId { get; set; }
    }
}
