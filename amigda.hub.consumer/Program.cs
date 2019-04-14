using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using System;
using System.Threading.Tasks;

namespace amigda.hub.consumer
{
    class Program
    {
        private const string ConnectionString = "Endpoint=sb://ihsuprodmlres005dednamespace.servicebus.windows.net/;SharedAccessKeyName=iothubowner;SharedAccessKey=4MTtHD2rFKHgaTcvxCKoVs9XddHcUgVT4zrYSu7rYbg=;EntityPath=iothub-ehub-ifhaiot-1465452-22d4cc6c37";
        static async Task Main(string[] args)
        {
            var hostName = "iothub-ehub-ifhaiot-1465452-22d4cc6c37";
            var eventHubConnectionString = "Endpoint=sb://ihsuprodmlres005dednamespace.servicebus.windows.net/;SharedAccessKeyName=iothubowner;SharedAccessKey=4MTtHD2rFKHgaTcvxCKoVs9XddHcUgVT4zrYSu7rYbg=;EntityPath=iothub-ehub-ifhaiot-1465452-22d4cc6c37";
            var stroageConnectionString = "DefaultEndpointsProtocol=https;AccountName=ifhaiotstorage01;AccountKey=ulqwbjLF/wSC+VbYkevDPZ0Wbk1DLXwd6++Q2lKGe+Bii722rZmnsZ+QG32qndaycUmVbnpUrJQqloPjzAqO+A==;EndpointSuffix=core.windows.net";
            var messageContainerName = "device-to-cloud-container";
            var consumerGroup = PartitionReceiver.DefaultConsumerGroupName;
            var processorHost = new EventProcessorHost(hostName, consumerGroup, eventHubConnectionString, stroageConnectionString, messageContainerName);
            await processorHost.RegisterEventProcessorAsync<AmidgaEventProcessor>();
            Console.ReadLine();
            await Task.Run(()=> { });

        }
    }
}
