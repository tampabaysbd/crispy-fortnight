using System.Web.Http;
using QDICodeChallenge.Web.Filters;
using Newtonsoft.Json.Serialization;

namespace QDICodeChallenge.Web
{
    public class CustomGlobalConfig
    {
        public static void Customize(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            config.Filters.Add(new ValidationActionFilter());
        }
    }
}