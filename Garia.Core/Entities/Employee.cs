using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.Entities
{
    public class Employee
    {
        [DisplayName("Employee Id")]
        public int EmployeeId { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string Fname { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string Lname { get; set; }

        public string PicturePath { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
        [DisplayName("Role")]
        [Required]
        public int RoleId { get; set; }
        [Required]
        [Range(1, int.MaxValue,
       ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public float Budget { get; set; }


    }
}
