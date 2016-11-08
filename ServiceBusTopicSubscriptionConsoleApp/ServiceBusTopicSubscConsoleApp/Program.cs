using System;
using Microsoft.Azure;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

// help: https://azure.microsoft.com/en-us/documentation/articles/service-bus-dotnet-how-to-use-topics-subscriptions/
// Install these two nuget packages: Microsoft.WindowsAzure.ConfigurationManager and WindowsAzure.ServiceBus
namespace ServiceBusTopicSubscConsoleApp
{
    class Program
    {
        private static readonly string ConnectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
        private static readonly NamespaceManager NamespaceManager =
            NamespaceManager.CreateFromConnectionString(ConnectionString);

        static void Main(string[] args)
        {
            // CreateTopic();
            // CreateSubscription();
            // CreateSubscriptionWithLowFilter();
            // CreateSubscriptionWithHighFilter();
            // SendMessagesToATopic();
            // ReceiveMessagesFromASubscription();
             DeleteTopic();
            // DeleteSubscription();
        }

        private static void DeleteSubscription()
        {
            NamespaceManager.DeleteSubscription("TestTopic", "HighMessages");
        }

        private static void DeleteTopic()
        {
            // Delete Topic.
            NamespaceManager.DeleteTopic("TestTopic");
        }

        private static void ReceiveMessagesFromASubscription()
        {
            SubscriptionClient Client =
                SubscriptionClient.CreateFromConnectionString
                        (ConnectionString, "TestTopic", "HighMessages");

            // Configure the callback options.
            OnMessageOptions options = new OnMessageOptions();
            options.AutoComplete = false;
            options.AutoRenewTimeout = TimeSpan.FromMinutes(1);

            Client.OnMessage((message) =>
            {
                try
                {
                    // Process message from subscription.
                    Console.WriteLine("\n**High Messages**");
                    Console.WriteLine("Body: " + message.GetBody<string>());
                    Console.WriteLine("MessageID: " + message.MessageId);
                    Console.WriteLine("Message Number: " +
                        message.Properties["MessageNumber"]);

                    // Remove message from subscription.
                    message.Complete();
                    Console.ReadLine();
                }
                catch (Exception)
                {
                    // Indicates a problem, unlock message in subscription.
                    message.Abandon();
                }
            }, options);
            Console.ReadLine();
        }

        private static void SendMessagesToATopic()
        {
            TopicClient Client =
                TopicClient.CreateFromConnectionString(ConnectionString, "TestTopic");

            Client.Send(new BrokeredMessage());

            for (int i = 0; i < 15; i++)
            {
                // Create message, passing a string message for the body.
                BrokeredMessage message = new BrokeredMessage("Test message " + i);

                // Set additional custom app-specific property.
                message.Properties["MessageNumber"] = i;

                // Send message to the topic.
                Client.Send(message);
            }
        }

        private static void CreateSubscriptionWithLowFilter()
        {
            // Create a "LowMessages" filtered subscription.
            SqlFilter lowMessagesFilter =
               new SqlFilter("MessageNumber <= 3");

            NamespaceManager.CreateSubscription("TestTopic",
               "LowMessages",
               lowMessagesFilter);
        }

        private static void CreateSubscriptionWithHighFilter()
        {
            // Create a "HighMessages" filtered subscription.
            SqlFilter highMessagesFilter =
               new SqlFilter("MessageNumber > 3");

            NamespaceManager.CreateSubscription("TestTopic",
               "HighMessages",
               highMessagesFilter);
        }

        private static void CreateSubscription()
        {
            if (!NamespaceManager.SubscriptionExists("TestTopic", "AllMessages"))
            {
                NamespaceManager.CreateSubscription("TestTopic", "AllMessages");
            }
        }

        private static void CreateTopic()
        {
            // Configure Topic Settings.
            TopicDescription td = new TopicDescription("TestTopic");
            td.MaxSizeInMegabytes = 5120;
            td.DefaultMessageTimeToLive = new TimeSpan(0, 1, 0);

            if (!NamespaceManager.TopicExists("TestTopic"))
            {
                NamespaceManager.CreateTopic(td);
            }
        }
    }
}
