using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;


namespace Microsoft.Dynamics365.Integrations.Function
{
    public static class ContactsListener
    {
        [FunctionName("ContactsListener")]
        public static void Run([ServiceBusTrigger("myNewTopic", "myNewSubscription", 
            AccessRights.Manage, 
            Connection = "MySBConnectionString")]string mySbMsg, 
            TraceWriter log)
        {
            log.Info($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
            var httpClient = new HttpClient();
            var contextObject = JsonConvert.DeserializeObject<RootObject>(mySbMsg);
            var json = JsonConvert.SerializeObject(Contact.GetContactObject(contextObject));
            var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = httpClient.PostAsync("Paste-Your-Request-Bin-URL-Here", content).Result; //TODO
            if (response.IsSuccessStatusCode)
            {
                log.Info($"Message sent to Request Bin API: {json}");
            }
            else
            {
                log.Info($"Message NOT sent to Request Bin API: {json}, Staus Code = {response.StatusCode}, " +
                    $"Resonse Content = {response.Content.ReadAsStringAsync().Result}" );
            }
        }

        
    }
}
