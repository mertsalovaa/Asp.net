using GamesStore_dal.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameesStore_client.Utils
{
    public class AppUserManager : UserManager<CustomUser>
    {
        public AppUserManager(IUserStore<CustomUser> store) : base(store)
        { }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext owinContext)
        {
            var dbContext = owinContext.Get<DbContext>();
            var manager = new AppUserManager(new UserStore<CustomUser>(dbContext));

            manager.UserValidator = new UserValidator<CustomUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequireDigit = true,
                RequiredLength = 6,
                RequireLowercase = true,
                RequireNonLetterOrDigit = true,
                RequireUppercase = true
            };

            var dataProtectionProvider = options.DataProtectionProvider;
            if(dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<CustomUser>(dataProtectionProvider.Create("Token"));
            }

            return manager;
        } 
    }
}