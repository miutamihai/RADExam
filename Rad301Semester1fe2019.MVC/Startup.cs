using ActivityTracker;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rad301Semester1fe2019.MVC.Startup))]
namespace Rad301Semester1fe2019.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Activity.Track("RAD301fe2019 Started");
            ConfigureAuth(app);
        }
    }
}
