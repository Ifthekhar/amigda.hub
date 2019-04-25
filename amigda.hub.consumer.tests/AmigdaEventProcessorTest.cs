using Microsoft.Azure.EventHubs.Processor;
using System;
using Xunit;

namespace amigda.hub.consumer.tests
{
    public class AmigdaEventProcessorTest
    {
        private IEventProcessor _eventProcessor;
        public AmigdaEventProcessorTest()
        {
            _eventProcessor = new AmidgaEventProcessor();
        }
        [Fact]
        public void Test1()
        {
            //Assign
            
        }
    }
}
