using System;
using Microsoft.ServiceBus.Messaging;

// help: https://azure.microsoft.com/en-us/documentation/articles/service-bus-dotnet-get-started-with-queues/
// Receive messages from the queue
namespace ServiceBusConsoleGetMessageApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Endpoint=sb://amaga6257namespace.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=5udu/E3hw/anT7XyloHQRjZ4bZlxH5IeteTs63fnUkk=";
            var queueName = "amaga6257servicequeue";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);

            client.OnMessage(message =>
            {
                Console.WriteLine(String.Format("Message body: {0}", message.GetBody<String>()));
                Console.WriteLine(String.Format("Message id: {0}", message.MessageId));
            });

            Console.ReadLine();
        }
    }
}
