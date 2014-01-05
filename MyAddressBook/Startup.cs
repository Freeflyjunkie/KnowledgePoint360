using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyAddressBook.Startup))]
namespace MyAddressBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
