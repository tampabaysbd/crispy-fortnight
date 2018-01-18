using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using QDICodeChallenge.Models;

namespace QDICodeChallenge.Web.ViewModels
{
    public class ContactViewModel
    {
        public Contact contact { get; set; }
        public bool IsAdd { get; set; }

        public ContactViewModel() : this(new Contact()) { }
        
        public ContactViewModel(Contact entity)
        {
           if (entity.zipcode == null)
            {
                entity.zipcode = new ZipCode(); 
            }
            contact = entity;
        }

        public string JSONContact
        {
            get
            {
                JsonSerializerSettings settings =
                    new JsonSerializerSettings();

                settings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();

                return JsonConvert.SerializeObject(this.contact, settings); ;
            }
        }
    }
}