using System;
using System.Data.Entity;
using System.Threading.Tasks;
using GameesStore_client.Utils;
using GamesStore_dal;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

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
        }
    }
}
