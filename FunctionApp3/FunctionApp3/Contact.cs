using System.Linq;

namespace Microsoft.Dynamics365.Integrations.Function
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BusinessPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }

        public static Contact GetContactObject(RootObject rootObject)
        {
            var firstName = rootObject.InputParameters[0].value.Attributes.Where(x => x.key.Equals("firstname")).FirstOrDefault()?.value;
            var lasttName = rootObject.InputParameters[0].value.Attributes.Where(x => x.key.Equals("lastname")).FirstOrDefault()?.value;
            var jobtitle = rootObject.InputParameters[0].value.Attributes.Where(x => x.key.Equals("jobtitle")).FirstOrDefault()?.value;
            var businessPhone = rootObject.InputParameters[0].value.Attributes.Where(x => x.key.Equals("telephone1")).FirstOrDefault()?.value;
            var mobilePhone = rootObject.InputParameters[0].value.Attributes.Where(x => x.key.Equals("mobilephone")).FirstOrDefault()?.value;
            var email = rootObject.InputParameters[0].value.Attributes.Where(x => x.key.Equals("emailaddress1")).FirstOrDefault()?.value;
            var contact = new Contact()
            {
                FirstName = firstName?.ToString(),
                LastName = lasttName?.ToString(),
                BusinessPhone = businessPhone?.ToString(),
                Email = email?.ToString(),
                JobTitle = jobtitle?.ToString(),
                MobilePhone = mobilePhone?.ToString()
            };
            return contact;
        }
    }
}