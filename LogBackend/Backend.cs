using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Neo.Plugins
{
	internal class Backend
    {
		private static readonly HttpClient client = new HttpClient();
		public static async Task Send(string log, string backend) {
			try
            {
				var message = new HttpRequestMessage(HttpMethod.Post, backend);
                message.Content = new StringContent(log);
                var resp = await client.SendAsync(message);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("[LogBackend] http exception: {0}", e.Message);
            }
		}
    }
}
