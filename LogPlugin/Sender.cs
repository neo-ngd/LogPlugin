using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Neo.Plugins
{
    internal static class Sender
    {
        private static readonly HttpClient client = new HttpClient();
        private static string name;
        public static void SetFrom(string n)
        {
            name = n.Contains("@") ? n : n + "@neo";
        }
        public static void Send(string log, string backend)
        {
            try
            {
                var message = new HttpRequestMessage(HttpMethod.Post, backend);
                message.Content = new StringContent(log);
                message.Headers.From = name;
                var task = client.SendAsync(message);
                var rep = task.Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("[LogPlugin] http exception: {0}", e.Message);
            }
        }
    }
}
