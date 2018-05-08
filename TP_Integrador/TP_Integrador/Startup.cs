using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TP_Integrador.Startup))]
namespace TP_Integrador
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
