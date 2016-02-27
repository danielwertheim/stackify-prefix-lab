using System.Web.Http;
using Owin;

namespace SampleWebApi
{
public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        var config = new HttpConfiguration();
        config.MapHttpAttributeRoutes();

        app.UseWebApi(config);
    }
}
}