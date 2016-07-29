using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApi.Models
{
    public class Session
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Room { get; set; }

        public string Tags { get; set; }

        public List<SessionSpeaker> SessionSpeakers { get; set; }
    }
}
