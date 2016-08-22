using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garia.Core.Entities;
namespace Garia.Models
{
    public class EmployeeModel
    {
        public Employee employee { get; set; }
        public List<Role> Roles { get; set; }
        public List<Employee> EmployeeList{ get; set; }

    }
}