using Garia.Core.Entities;
using Garia.Core.Handlers;
using Garia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garia.Controllers
{
    public class EmployeeController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Employee()
        {
            EmployeeModel model = new EmployeeModel();
            model.EmployeeList = EmployeeHandler.GetAllEmployees();
            model.Roles = EmployeeHandler.GetRoles();

            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateEmployee(Employee Employee, int RoleId)
        {
            //if role is beneaf sales mangager budget should not be countet therefor it is set to 0
            if (RoleId > 2)
            {
                Employee.Budget = 0;
            }
            EmployeeHandler.CreateEmployee(Employee.Fname, Employee.Lname, Employee.PicturePath, Employee.Email, Employee.Password, RoleId, Employee.Budget);

            EmployeeModel model = new EmployeeModel();
            model.EmployeeList = EmployeeHandler.GetAllEmployees();
            model.Roles = EmployeeHandler.GetRoles();

            return PartialView("_EmployeeList", model.EmployeeList);
        }
        [Authorize]
        [HttpGet]
        public ActionResult EditEmployee(int Id)
        {
            Employee model = EmployeeHandler.GetEmployeeById(Id);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditEmployee(Employee model)
        {

            if (ModelState.IsValid)
            {
                EmployeeHandler.Update(model.EmployeeId, model.Fname, model.Lname, model.PicturePath, model.Email, model.Password, model.RoleId, model.Budget);

                return RedirectToAction("Employee");

            }
            return View(model);
        }
	}
}