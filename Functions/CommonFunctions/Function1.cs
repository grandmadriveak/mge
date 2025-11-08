using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client.Events;

namespace CommonFunctions
{
    public class Function1
    {
        [FunctionName("sendmemail")]
        public void Run([RabbitMQTrigger("SendingEmail.v1", ConnectionStringSetting = "RabbitMQConnectionString")] BasicDeliverEventArgs myQueueItem, ILogger log)
        {
            var body = System.Text.Encoding.UTF8.GetString(myQueueItem.Body.ToArray());
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
