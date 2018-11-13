using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DoinikSokal.Models.Models;

namespace DoinikSokal.ViewModels
{
    public class SportsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string PostDate { get; set; }
    }
}