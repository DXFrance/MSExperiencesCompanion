namespace TextAnalytics
{
    using System;
    using System.IO;
    using System.Net.Http;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Threading;
    using System.Text;


    /// <summary>
    /// A wrapper class to invoke Recommendations REST APIs
    /// </summary>
    public class TextAnalyticsApiWrapper
    {
        private readonly HttpClient _httpClient;
        public string BaseUri;

        /// <summary>
        /// Constructor that initializes the Http Client.
        /// </summary>
        /// <param name="accountKey">The account key</param>
        public TextAnalyticsApiWrapper(string accountKey, string baseUri)
        {
            BaseUri = baseUri;

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUri),
                Timeout = TimeSpan.FromMinutes(5),
                DefaultRequestHeaders =
                {
                    {"Ocp-Apim-Subscription-Key", accountKey}
                }
            };
        }

        public int GetSentiment(string sentimentText)
        {
            string uri = BaseUri + "/sentiment";
            //TODO : serialize an object and use JsonContent instead of StringContent
            string text = @"{
                           ""documents"": [
                                    {
                                        ""language"": ""en"",
                                        ""id"": ""1"",
                                        ""text"": """ + sentimentText + @"""
                                    }
                                ]
                            }";

            var response = _httpClient.PostAsync(uri, new StringContent(text, Encoding.UTF8, "application/json")).Result;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(
                    String.Format("Error {0}: Failed to get sentiment, Reason: {1}",
                    response.StatusCode, ExtractErrorInfo(response)));
            }

            var result = response.Content.ReadAsStringAsync().Result;

            //TODO : desarialize object
            //var round = Math.Round(result * 10, 0);

            return 2;
        }

        /// <summary>
        /// Extract error message from the httpResponse, (reason phrase + body)
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static string ExtractErrorInfo(HttpResponseMessage response)
        {
            string detailedReason = null;
            if (response.Content != null)
            {
                detailedReason = response.Content.ReadAsStringAsync().Result;
            }
            var errorMsg = detailedReason == null ? response.ReasonPhrase : response.ReasonPhrase + "->" + detailedReason;
            return errorMsg;

        }

        /// <summary>
        /// Extract error information from HTTP response message.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        internal static string ExtractReponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            string detailedReason = null;
            if (response.Content != null)
            {
                detailedReason = response.Content.ReadAsStringAsync().Result;
            }
            var errorMsg = detailedReason == null ? response.ReasonPhrase : response.ReasonPhrase + "->" + detailedReason;

            string error = String.Format("Status code: {0}\nDetail information: {1}", (int)response.StatusCode, errorMsg);
            throw new Exception("Response: " + error);
        }
    }

    /// <summary>
    /// Utility class holding the result of import operation
    /// </summary>
    internal class ImportReport
    {
        public string Info { get; set; }
        public int ErrorCount { get; set; }
        public int LineCount { get; set; }

        public override string ToString()
        {
            return string.Format("successfully imported {0}/{1} lines for {2}", LineCount - ErrorCount, LineCount,
                Info);
        }
    }
}
