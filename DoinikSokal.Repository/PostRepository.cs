using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoinikSokal.Models.Models;
using DoinikSokal.Repository.Base;
using DoinikSokal.Repository.Contracts;

namespace DoinikSokal.Repository
{
    public class PostRepository:Repository<Post>, IPostRepository
    {
        public PostRepository(DbContext db) : base(db)
        {
        }
    }
}
