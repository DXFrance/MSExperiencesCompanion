using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InwinkLibrary.Models
{
    public class Session
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("room")]
        public string Room { get; set; }
        [JsonProperty("tags")]
        public string Tags { get; set; }
        [JsonProperty("sessionSpeakers")]
        public SessionSpeaker[] Speakers { get; set; }
    }
}
