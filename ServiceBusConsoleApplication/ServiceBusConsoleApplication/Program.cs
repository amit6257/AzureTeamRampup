using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

// help: https://azure.microsoft.com/en-us/documentation/articles/service-bus-dotnet-get-started-with-queues/
// followed the instructions here, created a subscriptio - Free Trial, created a namespace, create a service Queue,
// This app sends a message to the queue, which updates Active Message count in the queue, see it in portal.
namespace ServiceBusConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Endpoint=sb://amaga6257namespace.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=5udu/E3hw/anT7XyloHQRjZ4bZlxH5IeteTs63fnUkk=";
            var queueName = "amaga6257servicequeue";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            var message = new BrokeredMessage("This is a test message!");
            client.Send(message);
        }
    }
}
