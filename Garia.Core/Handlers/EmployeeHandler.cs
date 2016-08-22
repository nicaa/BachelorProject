using BLToolkit.Reflection;
using Garia.Core.DAO;
using Garia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.Handlers
{
     public class EmployeeHandler
    {
         public static List<Employee> GetAllEmployees()
         {
             EmployeeDAO employee = TypeAccessor<EmployeeDAO>.CreateInstance();
             return employee.GetAllEmployees();   
         }
         public static List<Employee> GetAllManagers()
         {
             EmployeeDAO employee = TypeAccessor<EmployeeDAO>.CreateInstance();
             return employee.GetAllManagers();
         }

         public static int CreateEmployee(string Fname, string Lname, string PicturePath, string Email, string Password, int RoleID, float Budget)
         {
             EmployeeDAO employee = TypeAccessor<EmployeeDAO>.CreateInstance();
             return employee.CreateEmployee(Fname, Lname, PicturePath, Email, Password, RoleID, Budget);
         }
         public static Employee GetEmployeeById(int EmployeeId)
         {
             EmployeeDAO employee = TypeAccessor<EmployeeDAO>.CreateInstance();
             return employee.GetEmployeeById(EmployeeId);
         }

         public static int DeleteEmployeeById(int EmployeeId)
         {
             EmployeeDAO employee = TypeAccessor<EmployeeDAO>.CreateInstance();
             return employee.DeleteEmployeeByID(EmployeeId);
         }
         public static Employee GetEmployeeByEmail(string Email)
         {
             EmployeeDAO employee = TypeAccessor<EmployeeDAO>.CreateInstance();
             return employee.GetEmployeeByEmail(Email);
         }
         public static List<Role> GetRoles()
         {
             EmployeeDAO employee = TypeAccessor<EmployeeDAO>.CreateInstance();
             return employee.GetRoles();
         }
         public static int Update(int EmployeeId,string Fname, string Lname, string PicturePath, string Email, string Password, int RoleID, float Budget)
         {
             EmployeeDAO employee = TypeAccessor<EmployeeDAO>.CreateInstance();
             return employee.Update(EmployeeId,Fname, Lname, PicturePath, Email, Password, RoleID, Budget);
         }
    }
}
