using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QDICodeChallenge.Web.Startup))]
namespace QDICodeChallenge.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
