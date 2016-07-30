using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InwinkLibrary.Models
{
    public class SessionSpeaker
    {
        [JsonProperty("sessionId")]
        public int SessionId { get; set; }
        [JsonProperty("session")]
        public Session Session { get; set; }
    }
}
