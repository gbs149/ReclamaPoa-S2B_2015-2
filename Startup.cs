using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReclamaPoa2013.Startup))]
namespace ReclamaPoa2013
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
