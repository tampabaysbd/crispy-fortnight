using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using QDICodeChallenge.Models;

namespace QDICodeChallenge.Web.ViewModels
{
    public class ContactsListViewModel
    {
        public IList<Contact> Contacts { get; set; }
        
        public string JSONContacts
        {
            get
            {
                JsonSerializerSettings settings =
                    new JsonSerializerSettings();

                settings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();

                return JsonConvert.SerializeObject(this.Contacts, settings); ;
            }
        }
    }
}