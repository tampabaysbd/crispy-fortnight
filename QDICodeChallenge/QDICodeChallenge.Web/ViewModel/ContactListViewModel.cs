using QDICodeChallenge.Models;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace QDICodeChallenge.Web.ViewModel
{
    public class ContactListViewModel
    {
        public IList<Contact> Contacts { get; set; }

        public string JsonContacts
        {
            get
            {
                JsonSerializerSettings settings =
                    new JsonSerializerSettings();

                settings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();

                var contacts = JsonConvert.SerializeObject(this.Contacts, settings);
                return contacts;
            }
        }
    }
}