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
using GamesStore_dal.Entities;
using AutoMapper;
using Microsoft.AspNet.Identity;

namespace GameesStore_client.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMapper mapper;
        public AuthController(IMapper _mapper)
        {
            mapper = _mapper;
        }

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
            if (status == SignInStatus.Success)
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

            var user = mapper.Map<CustomUser>(model);
            user.DateOfBirth = model.DateOfBirth.ToString().Substring(0, 10);
            var result = await manager.CreateAsync(user, model.Password);
            if (result.Succeeded)
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

        [HttpGet]
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Games");
        }

        public ActionResult Profile()
        {
            var manager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var user = manager.FindByName(User.Identity.Name);
            var model = mapper.Map<ProfileViewModel>(user);
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var manager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var user = manager.FindByName(User.Identity.Name);
            var model = mapper.Map<ProfileViewModel>(user);
            model.Login = User.Identity.Name;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProfileViewModel user)
        {
            var manager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            if (ModelState.IsValid)
            {
                var currentUser = mapper.Map<CustomUser>(manager.FindByName(User.Identity.Name));
                currentUser.DateOfBirth = user.DateOfBirth.ToString().Substring(0, 10);
                var result = await manager.UpdateAsync(currentUser);
                //var newPassword = await manager.PasswordValidator.ValidateAsync(user.Password);
                //await manager.ChangePasswordAsync(currentUser.Id, currentUser.PasswordHash, newPassword.ToString());
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Auth");
                }
                return RedirectToAction("Profile", "Auth");
            }
            else
            {
                return RedirectToAction("Edit", "Auth", user);
            }
        }
    }
}