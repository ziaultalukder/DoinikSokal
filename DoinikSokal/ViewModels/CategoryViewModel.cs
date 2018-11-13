using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoinikSokal.Model.Contracts;
using DoinikSokal.Models.Models;

namespace DoinikSokal.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SubCatId { get; set; }
        public virtual Category SubCat { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}