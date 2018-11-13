using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoinikSokal.Models.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace DoinikSokal.Identity.IdentityConfig
{
    public class AppSignInManager:SignInManager<AppUser, int>
    {
        public AppSignInManager(UserManager<AppUser, int> userManager, Microsoft.Owin.Security.IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }

        public static AppSignInManager Create(IdentityFactoryOptions<AppSignInManager> options, IOwinContext context)
        {
            return new AppSignInManager(context.GetUserManager<AppUserManager>(), context.Authentication);
        }
    }
}