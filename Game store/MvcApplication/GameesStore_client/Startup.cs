using System;
using System.Data.Entity;
using System.Threading.Tasks;
using GameesStore_client.Utils;
using GamesStore_dal;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using GamesStore_dal.Entities;

[assembly: OwinStartup(typeof(GameesStore_client.Startup))]

namespace GameesStore_client
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Register context for Identity
            app.CreatePerOwinContext<DbContext>(() => new ApplicationContext());
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<AppSignInManager>(AppSignInManager.Create);
            // Config identity
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Auth/Login")
            });

            CreateUsers();
        }

        private void CreateUsers()
        {
            var context = new ApplicationContext();
            var store = new UserStore<CustomUser>(context);
            var userManager = new UserManager<CustomUser>(store);

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var role = new IdentityRole
            {
                Name = "Admin"
            };
            roleManager.Create(role);

            var user = new CustomUser
            {
                UserName = "IrynaMertsalova",
                DateOfBirth = new DateTime(2004, 03, 10).ToShortDateString(),
                Name = "Iryna",
                Surname = "Mertsalova",
                Email = "irynamertsalova@gmail.com",
                Cart = new Cart()
            };
            userManager.Create(user, "Iryna10!");


            var admin = new CustomUser
            {
                UserName = "admin",
                Email = "admin@gmail.com"
            };

            userManager.Create(admin, "Admin1!");
            userManager.AddToRole(userManager.FindByName("admin").Id, "Admin");
        }
    }
}
