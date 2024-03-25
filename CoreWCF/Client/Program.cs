using System.ServiceModel;

namespace Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new WcfService.ServiceClient();

            var response = client.GetDataUsingDataContract(new WcfService.CompositeType
            {
                StringValue = "Hello",
                BoolValue = true
            });

            Console.WriteLine($"Output from RPC: {response.StringValue}");

            var baseUrl = $"{client.Endpoint.Address.Uri.Scheme}://{client.Endpoint.Address.Uri.Authority}/json/getdata?value=4";
            var jsonResponse = await new HttpClient().GetStringAsync( baseUrl );

            Console.WriteLine($"Output from JSON: {jsonResponse}");

            Console.ReadLine(); // to keep the window from closing
        }
    }
}
