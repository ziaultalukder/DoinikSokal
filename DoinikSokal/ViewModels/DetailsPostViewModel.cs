﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoinikSokal.Models.Models;

namespace DoinikSokal.ViewModels
{
    public class DetailsPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public double Views { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime PostDate { get; set; }
        public bool WithDeleted()
        {
            return IsDeleted;
        }
    }
}