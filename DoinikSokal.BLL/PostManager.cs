using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoinikSokal.BLL.Base;
using DoinikSokal.BLL.Contracts;
using DoinikSokal.Models.Models;
using DoinikSokal.Repository.Contracts;

namespace DoinikSokal.BLL
{
    public class PostManager:Manager<Post>, IPostManager
    {
        private IPostRepository postRepository;
        public PostManager(IPostRepository Repository) : base(Repository)
        {
            this.postRepository = Repository;
        }
    }
}
