using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoinikSokal.Models.DatabaseContext;
using DoinikSokal.Models.Models;
using DoinikSokal.Repository.Contracts;
using DoinikSokal.Repository.Base;

namespace DoinikSokal.Repository
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        

        public CategoryRepository(DbContext db) : base(db)
        {
        }
        
    }
}
