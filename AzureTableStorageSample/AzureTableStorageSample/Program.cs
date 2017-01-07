using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
// Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Table; // Namespace for Table storage types

// https://docs.microsoft.com/en-us/azure/storage/storage-dotnet-how-to-use-tables
namespace AzureTableStorageSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Retrieve a reference to the table.
            CloudTable table = tableClient.GetTableReference("peopleTABLE");

            // Create the table if it doesn't exist.
            table.CreateIfNotExists();

            // add an entity
            // Create a new customer entity.
            CustomerEntity customer = new CustomerEntity("Harp2", "Walter");
            customer.Email = "Walter@contoso.com";
            customer.PhoneNumber = "425-555-0101";

            // Create the TableOperation object that inserts the customer entity.
            TableOperation insertOperation = TableOperation.Insert(customer);

            // Execute the insert operation.
           // table.Execute(insertOperation);

           // doBatchOperation(table);

           // queryAPartition(table);
           getAllEntitiesFromTable(table);
//            deleteAllTableEntries(table);
          //  doConditionalQuery(table);
          UpdateCustomerEntity(customer, table);
            Console.Read();
        }

        private static void UpdateCustomerEntity(CustomerEntity customer, CloudTable table)
        {
            // Create a retrieve operation that takes a customer entity.
            TableOperation retrieveOperation = TableOperation.Retrieve<CustomerEntity>
                (customer.PartitionKey, customer.RowKey);

            TableResult result = table.Execute(retrieveOperation);

            CustomerEntity updatedCustomerEntity = (CustomerEntity) result.Result;
            updatedCustomerEntity.PhoneNumber = "aksjd";
            TableOperation updateOperation = TableOperation.Replace(updatedCustomerEntity);
            table.Execute(updateOperation);
        }

        private static void DeleteAllTableEntries(CloudTable table)
        {
            TableQuery query = new TableQuery();
            foreach (DynamicTableEntity entity in table.ExecuteQuery(query))
            {
                TableOperation deleteOperation = TableOperation.Delete(entity);
                table.Execute(deleteOperation);
            }
        }

        private void deleteAllQueues()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            for (int i = 0; i < 20; i++)
            {
                string s = "provisioning-operationsamaga";

                if (i <= 9)
                {
                    s += "0" + i;
                }
                else
                {
                    s += i;
                }
                CloudQueue queue = queueClient.GetQueueReference(s);

                // Fetch the queue attributes.
                queue.FetchAttributes();

                // Retrieve the cached approximate message count.
                int? cachedMessageCount = queue.ApproximateMessageCount;
                queue.Delete();
            }
        }

        private static void doConditionalQuery(CloudTable table)
        {
            // Create the table query.
            TableQuery<CustomerEntity> rangeQuery = new TableQuery<CustomerEntity>().Where(
                TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Smith"),
                    TableOperators.And,
                    TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.LessThan, "E")));

            // Loop through the results, displaying information about the entity.
            foreach (CustomerEntity entity in table.ExecuteQuery(rangeQuery))
            {
                Console.WriteLine("{0}, {1}\t{2}\t{3}", entity.PartitionKey, entity.RowKey,
                    entity.Email, entity.PhoneNumber);
            }
        }

        private static void queryAPartition(CloudTable table)
        {
            // Construct the query operation for all customer entities where PartitionKey="Smith".
            TableQuery<CustomerEntity> query = new TableQuery<CustomerEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Harp2"));

            // Print the fields for each customer.
            foreach (CustomerEntity entity in table.ExecuteQuery(query))
            {
                Console.WriteLine("{0}, {1}\t{2}\t{3}", entity.PartitionKey, entity.RowKey,
                    entity.Email, entity.PhoneNumber);
            }
        }

        private static void getAllEntitiesFromTable(CloudTable table)
        {
            TableQuery query = new TableQuery();
            foreach(DynamicTableEntity entity in table.ExecuteQuery(query))
            {
                Console.WriteLine("{0}, {1}", entity.PartitionKey, entity.RowKey);
            }
        }

        private static void doBatchOperation(CloudTable table)
        {
            // Create the batch operation.
            TableBatchOperation batchOperation = new TableBatchOperation();

            // Create a customer entity and add it to the table.
            CustomerEntity customer1 = new CustomerEntity("Smith", "Jeff");
            customer1.Email = "Jeff@contoso.com";
            customer1.PhoneNumber = "425-555-0104";

            // Create another customer entity and add it to the table.
            CustomerEntity customer2 = new CustomerEntity("Smith", "Ben");
            customer2.Email = "Ben@contoso.com";
            customer2.PhoneNumber = "425-555-0102";

            // Add both customer entities to the batch insert operation.
            batchOperation.Insert(customer1);
            batchOperation.Insert(customer2);

            // Execute the batch operation.
            table.ExecuteBatch(batchOperation);
        }
    }
}
