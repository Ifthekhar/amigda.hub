using Microsoft.Azure.Devices;
using System;
using System.Text;
using System.Threading.Tasks;

namespace amigda.cloud.to.device
{
    class Program
    {
        static ServiceClient serviceClient;
        static string connectionString = "HostName=ifhaiot.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=4MTtHD2rFKHgaTcvxCKoVs9XddHcUgVT4zrYSu7rYbg=";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
            await SendCloudToDeviceMessageAsync();
        }

        private async static Task SendCloudToDeviceMessageAsync()
        {
            var commandMessage = new Message(Encoding.ASCII.GetBytes("Message from clound"));
            await serviceClient.SendAsync("device-01", commandMessage);

        }
    }
}
