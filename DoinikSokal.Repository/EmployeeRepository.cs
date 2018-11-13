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
    public class EmployeeRepository:Repository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(DbContext db) : base(db)
        {
        }
    }
}
