using ActivityTracker;
using Microsoft.Owin;
using Owin;
using Rad301Semester1fe2019.MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(Rad301Semester1fe2019.MVC.Startup))]
namespace Rad301Semester1fe2019.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Activity.Track("RAD301fe2019 Started");
            SeedRoles();
            ConfigureAuth(app);
        }
        private void SeedRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var DataModelContext = new BusinessDomain.Classes.Context();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));



            if (!roleManager.RoleExists("Head Librarian"))

            {

                var role = new IdentityRole();

                role.Name = "Head Librarian";

                roleManager.Create(role);



                var user = new ApplicationUser();

                user.UserName = "miuta.mihai@gmail.com";

                user.Email = "miuta.mihai@gmail.com";



                string userPWD = "Mihai16.";



                var chkUser = UserManager.Create(user, userPWD);



                if (chkUser.Succeeded)

                {

                    var result1 = UserManager.AddToRole(user.Id, "Head Librarian");



                }

            }

            if (!roleManager.RoleExists("Librarian"))

            {

                var role = new IdentityRole();

                role.Name = "Librarian";

                roleManager.Create(role);
                var user = new ApplicationUser();

                user.UserName = "powell.paul@itsligo.ie";

                user.Email = "powell.paul@itsligo.ie";



                string userPWD = "TheLibrarian$1";



                var chkUser = UserManager.Create(user, userPWD);



                if (chkUser.Succeeded)

                {

                    var result1 = UserManager.AddToRole(user.Id, "Librarian");



                }


            }



            if (!roleManager.RoleExists("Member"))

            {

                var role = new IdentityRole();

                role.Name = "Member";

                roleManager.Create(role);



                foreach (var member in DataModelContext.Members)

                {

                    var user = new ApplicationUser();

                    string libraryDomain = "@theradlibrary.ie";

                    user.UserName = member.FirstName + member.LastName + libraryDomain;

                    user.Email = user.UserName;



                    string userPWD = member.FirstName + "$1";



                    var chkUser = UserManager.Create(user, userPWD);



                    if (chkUser.Succeeded)

                    {

                        var result1 = UserManager.AddToRole(user.Id, role.Name);



                    }

                }

            }

        }
    }
}
