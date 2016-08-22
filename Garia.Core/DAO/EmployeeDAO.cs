using BLToolkit.DataAccess;
using Garia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.DAO
{
    public abstract class EmployeeDAO : DataAccessor
    {
        [SprocName("tblEmployee_GetAllEmployees")]
        public abstract List<Employee> GetAllEmployees();

        [SprocName("tblEmployee_GetAllSaleManagers")]
        public abstract List<Employee> GetAllManagers();

        [SprocName("tblEmployee_CreateEmployee")]    
        public abstract int CreateEmployee(string Fname, string Lname, string PicturePath, string Email, string Password, int RoleID, float Budget);

        [SprocName("tblEmployee_GetEmployeeById")]
        public abstract Employee GetEmployeeById(int EmployeeId);
    
        [SprocName("tblEmployee_DeleteEmployeeById")]
        public abstract int DeleteEmployeeByID(int EmployeeId);

        [SprocName("tblEmployee_GetEmployeeByEmail")]
        public abstract Employee GetEmployeeByEmail(string Email);

        [SprocName("tblRole_GetRoles")]
        public abstract List<Role> GetRoles();

        [SprocName("tblEmployee_Update")]
        public abstract int Update(int EmployeeId, string Fname, string Lname, string PicturePath, string Email, string Password, int RoleID, float Budget);

    

    }
}
