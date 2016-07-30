using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApi.Models
{
    public class SessionSpeaker
    {
        public int SessionId { get; set; }

        [JsonIgnore]
        public Session Session { get; set; }

        public int SpeakerId { get; set; }

        [JsonIgnore]
        public Speaker Speaker { get; set; }
    }
}
