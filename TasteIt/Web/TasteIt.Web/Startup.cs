using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TasteIt.Web.Startup))]

namespace TasteIt.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
