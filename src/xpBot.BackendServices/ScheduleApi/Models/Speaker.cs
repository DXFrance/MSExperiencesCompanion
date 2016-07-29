using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApi.Models
{
    public class Speaker
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Twitter { get; set; }

        public List<SessionSpeaker> SessionSpeakers { get; set; }
    }
}
