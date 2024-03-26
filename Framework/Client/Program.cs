using Client.WcfService;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new ServiceClient();

            var response = client.GetDataUsingDataContract(new WcfService.CompositeType
            {
                StringValue = "Hello",
                BoolValue = true
            });

            Console.WriteLine($"Output from RPC: {response.StringValue}");
            Console.WriteLine($"Output from JSON: {await GetJsonResponse(client)}");

            Console.ReadLine(); // to keep the window from closing
        }

        private static async Task<string> GetJsonResponse(ServiceClient client)
        {
            var baseUrl = $"{client.Endpoint.Address.Uri.OriginalString}/json/getdata?value=4";
            return await new HttpClient().GetStringAsync(baseUrl);
        }
    }
}
