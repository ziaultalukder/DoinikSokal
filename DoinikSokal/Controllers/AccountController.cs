using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DoinikSokal.Identity.IdentityConfig;
using DoinikSokal.Models.Models.Identity;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace DoinikSokal.Controllers
{
    [RoutePrefix("doiniksokal")]
    public class AccountController : Controller
    {
        public AppUserManager _UserManager { get; set; }
        public AppSignInManager _SignInManager { get; set; }
        private AuthenticationManager authenticationManager;

        public AppUserManager UserManager
        {
            get { return _UserManager ?? HttpContext.GetOwinContext().GetUserManager<AppUserManager>(); ; }
        }

        public AppSignInManager SignInManager
        {
            get { return _SignInManager ?? HttpContext.GetOwinContext().GetUserManager<AppSignInManager>(); ; }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [Authorize]
        public ActionResult Register()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AllUsers()
        {
            var allUser = UserManager.Users.ToList().OrderByDescending(c=>c.Id);
            return View(allUser);
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            var user = new AppUser()
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email

            };
            var result = UserManager.Create(user, registerViewModel.Password);
            if (result.Succeeded)
            {
                SignInManager.SignIn(user, false, false);
                return RedirectToAction("AllUsers", "Account");
            }
            return View();
        }

        [Route("Login")]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("Login")]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = SignInManager.PasswordSignIn(model.Email, model.Password, model.RememberMe, false);
                if (result == SignInStatus.Success)
                {
                    return RedirectToLocal(returnUrl);
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Manager");
        }
    }
}