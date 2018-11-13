using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoinikSokal.BLL.Base;
using DoinikSokal.BLL.Contracts;
using DoinikSokal.Models.Models;
using DoinikSokal.Repository;
using DoinikSokal.Repository.Contracts;

namespace DoinikSokal.BLL
{
    public class CategoryManager:Manager<Category>, ICategoryManager
    {
        private ICategoryRepository categoryRepository;
        public CategoryManager(ICategoryRepository baseRepository) : base(baseRepository)
        {
            categoryRepository = baseRepository;
        }
        
    }
}
