using System;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new WcfService.ServiceClient();

            var response = client.GetDataUsingDataContract(new WcfService.CompositeType
            {
                StringValue = "Hello",
                BoolValue = true
            });

            Console.WriteLine(response.StringValue);

            Console.ReadLine(); // to keep the window from closing
        }
    }
}
