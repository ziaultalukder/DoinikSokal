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
    public class EmployeeManager:Manager<Employee>, IEmployeeManager
    {
        private IEmployeeRepository employeeRepository;
        public EmployeeManager(IEmployeeRepository baseRepository) : base(baseRepository)
        {
            employeeRepository = baseRepository;
        }
    }
}
