using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DoinikSokal.Identity.IdentityConfig;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DoinikSokal.Models.Models.Identity
{
    public class AppUser:IdentityUser<int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public ClaimsIdentity GenerateUserIdentity(AppUserManager manager)
        {
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
