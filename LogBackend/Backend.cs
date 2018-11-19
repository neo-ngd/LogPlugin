using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Neo.Plugins
{
	internal static class Backend
    {
        private static readonly HttpClient client = new HttpClient();
        public static void Send(string log, string backend) 
        {
            try
            {
                var message = new HttpRequestMessage(HttpMethod.Post, backend);
                message.Content = new StringContent(log);
                var task = client.SendAsync(message);
				var rep = task.Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("[LogBackend] http exception: {0}", e.Message);
            }
        }
    }
}
