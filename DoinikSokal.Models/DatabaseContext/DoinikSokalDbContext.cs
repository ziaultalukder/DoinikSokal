using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoinikSokal.Models.Models;
using DoinikSokal.Models.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DoinikSokal.Models.DatabaseContext
{
    //IdentityDbContext<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
    public class DoinikSokalDbContext: IdentityDbContext<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public DoinikSokalDbContext():base("name = DoinikSokalDbContext")
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Post> Posts { get; set; }
        public static DoinikSokalDbContext Create()
        {
            return new DoinikSokalDbContext();
        }
    }
}
