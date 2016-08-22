using Garia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garia.Models
{
    public class TaskCreateEditModel
    {
        public GariaTask Task { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public List<TaskPriority> prioritiesList { get; set; }

    }
}