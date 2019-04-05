using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(IMSBIZZ.Startup))]
namespace IMSBIZZ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
