using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InwinkLibrary.Models;
using InwinkLibrary.Helpers;

namespace InwinkLibrary
{
    public sealed class InwinkClient : SimpleServiceClient, IInwinkClient
    {
        private Uri _hostUri = new Uri("http://xpbot-dev.westus.cloudapp.azure.com:8782");

        public async Task<Session> GetSessionById(int id)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("id", id.ToString());

            var template = new UriTemplate("/api/sessions/{id}");
            return await GetWithRetryAsync<Session>(_hostUri, template, parameters);
        }

        public async Task<List<Session>> GetSessions()
        {
            var parameters = new Dictionary<string, string>();

            var template = new UriTemplate("/api/sessions/");
            return await GetWithRetryAsync<List<Session>>(_hostUri, template, parameters);
        }

        public async Task<Speaker> GetSpeakerById(int id)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("id", id.ToString());

            var template = new UriTemplate("/api/speakers/{id}");
            return await GetWithRetryAsync<Speaker>(_hostUri, template, parameters);
        }

        public async Task<List<Speaker>> GetSpeakers()
        {
            var parameters = new Dictionary<string, string>();

            var template = new UriTemplate("/api/speakers");
            return await GetWithRetryAsync<List<Speaker>>(_hostUri, template, parameters);
        }
    }
}
