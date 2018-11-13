using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoinikSokal.Models.Models.Identity;
using Microsoft.AspNet.Identity;

namespace DoinikSokal.Identity.IdentityConfig
{
    public class AppRoleManager:RoleManager<AppRole, int>
    {
        public AppRoleManager(IRoleStore<AppRole, int> store) : base(store)
        {
        }
    }
}