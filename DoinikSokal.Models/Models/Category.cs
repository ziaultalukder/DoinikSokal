using DoinikSokal.Model.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoinikSokal.Models.Models
{
    public class Category:IModel, IDeletable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SubCatId { get; set; }
        public virtual Category SubCat { get; set; }
        public bool IsDeleted { get; set; }

        bool IDeletable.WithDeleted()
        {
            return IsDeleted;
        }
        
    }
}
