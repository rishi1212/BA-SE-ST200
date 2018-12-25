using System.IO;
using System.Net.Http;
using System.Text;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;

namespace Microsoft.Dynamics365.Integrations.WebJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void WriteLog([ServiceBusTrigger("myNewTopic", "myNewSubscription")] string message,
        TextWriter logger)
        {
            logger.WriteLine("Topic message: " + message);
            var httpClient = new HttpClient();
            var contextObject = JsonConvert.DeserializeObject<RootObject>(message);
            var json = JsonConvert.SerializeObject(Contact.GetContactObject(contextObject));
            var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = httpClient.PostAsync("Paste-Your-Request-Bin-URL-Here", content).Result; //TODO
            if (response.IsSuccessStatusCode)
            {
                logger.WriteLine($"Message sent to Request Bin API: {json}");
            }
            else
            {
                logger.WriteLine($"Message NOT sent to Request Bin API: {json}, Staus Code = {response.StatusCode}, " +
                    $"Resonse Content = {response.Content.ReadAsStringAsync().Result}");
            }
        }
    }
}
