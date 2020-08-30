using GameesStore_client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using GameesStore_client.Utils;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace GameesStore_client.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var signInManager = HttpContext.GetOwinContext().Get<AppSignInManager>();
            var status = signInManager.PasswordSignIn(model.Login, model.Password, false, false);
            if(status == SignInStatus.Success)
            {
                return RedirectToAction("Index", "Games");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var manager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var user = new IdentityUser
            {
                UserName = model.Login,
                Email = model.Email
            };
            var result = await manager.CreateAsync(user, model.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                var errors = "";
                foreach (var item in result.Errors)
                {
                    errors += item + "\n";
                }
            }
            
            return View();
        }
    }
}