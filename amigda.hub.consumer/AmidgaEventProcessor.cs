using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace amigda.hub.consumer
{
    public class AmidgaEventProcessor : IEventProcessor
    {
        public AmidgaEventProcessor()
        {

        }
        public Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            Console.WriteLine($"Event closing with {context.PartitionId }");
            return Task.CompletedTask;
        }

        public Task OpenAsync(PartitionContext context)
        {
            Console.WriteLine($"Event opening with {context.PartitionId}");
            return Task.CompletedTask;
        }

        public Task ProcessErrorAsync(PartitionContext context, Exception error)
        {
            Console.WriteLine($"Process Error event { error.Message}");
            return Task.CompletedTask;
        }

        public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            foreach (var message in messages)
            {
                var data =Encoding.Default.GetString(message.Body);
                Console.WriteLine(data);
            }
            return context.CheckpointAsync();
        }
    }
}
