using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garia.Models
{
    public static class MyUserRole
    {
        public static int MyRole {
            get {
                HttpCookie Role = System.Web.HttpContext.Current.Request.Cookies["Role"];
                int role = Convert.ToInt32(Role.Value);
                return role;
            } 
        }
        public static int Admin
        {
            get
            {
                return 1;
            }
        }
        public static int SalesManager
        {
            get
            {
                return 2;
            }
        }
        public static int Employee
        {
            get
            {
                return 3;
            }
        }
    
    }
}