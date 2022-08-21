using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AERP.Web.UI.Startup))]
namespace AERP.Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
