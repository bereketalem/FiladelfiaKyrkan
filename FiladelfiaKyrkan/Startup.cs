using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FiladelfiaKyrkan.Startup))]
namespace FiladelfiaKyrkan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
