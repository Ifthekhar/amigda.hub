using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;

namespace amigda.device.client
{
    class Program
    {
        private const string DeviceConnectionString = "HostName=ifhaiot.azure-devices.net;SharedAccessKeyName=device;DeviceId=device-01;SharedAccessKey=B7N2BQEqZJmB0oI5Vax/4A3NmjQkIppnvx9sHz1zPXk=";
        
        static async Task Main(string[] args)
        {
            try
            {
                var deviceClient = DeviceClient.CreateFromConnectionString(DeviceConnectionString);
                await deviceClient.OpenAsync();
                var msseageBytes = Encoding.ASCII.GetBytes($" Amigda night {DateTime.Today.ToShortDateString()}");
                var message = new Message(msseageBytes);
                await deviceClient.SendEventAsync(message);
                Console.WriteLine("Device is connected");
                Console.WriteLine("Hello World from Amigda");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
            Console.Read();
        }
    }
}
