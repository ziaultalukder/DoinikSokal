using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoinikSokal.Models.Models;

namespace DoinikSokal.ViewModels
{
    public class CategoryDropDownViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int? SubCatId { get; set; }
        public Category SubCat { get; set; }
    }
}