using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Garia.Core.Entities
{
    public class Sale
    {
        [Required]
        public int SaleId { get; set; }

        [Required]

        public float Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required]     
        public int DealerId { get; set; }
        public string  Fname { get; set; }
        public string Lname { get; set; }
        public string CarType { get; set; }
        public string DealerName { get; set; }
    }
}
