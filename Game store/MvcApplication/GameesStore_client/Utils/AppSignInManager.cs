using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameesStore_client.Utils
{
    public class AppSignInManager : SignInManager<IdentityUser, string>
    {
        public AppSignInManager(AppUserManager manager, IAuthenticationManager authenticationManager) 
            : base(manager, authenticationManager)
        {  }

        public static AppSignInManager Create(IdentityFactoryOptions<AppSignInManager> options, IOwinContext owinContext)
        {
            var userManager = owinContext.GetUserManager<AppUserManager>();
            var signInManager = new AppSignInManager(userManager, owinContext.Authentication);

            return signInManager;
        }
    }
}