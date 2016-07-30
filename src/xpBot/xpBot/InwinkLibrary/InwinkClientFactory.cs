using System;

namespace InwinkLibrary
{
    public static class InwinkClientFactory
    {
        /// <summary>
        /// Create The Inwink Platform client
        /// </summary>
        public static IInwinkClient CreateInwinkClient()
        {
            return new InwinkClient();
        }
    }
}
