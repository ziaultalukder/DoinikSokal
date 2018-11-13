using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoinikSokal.Model.Contracts;

namespace DoinikSokal.Models.Models
{
    public class Employee:IModel, IDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string FilePath { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsDeleted { get; set; }
        public bool WithDeleted()
        {
            return IsDeleted;
        }
    }
}
