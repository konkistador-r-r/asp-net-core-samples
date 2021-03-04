using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DefTplMVCIndividualAuth.Startup))]
namespace DefTplMVCIndividualAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
