using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garia.Core.Entities;

namespace Garia.Models
{
    public class SaleManagerGraphModel
    {
        public List<Employee> Employees { get; set; }
        public Employee employee { get; set; }
    }
}