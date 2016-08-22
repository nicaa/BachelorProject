using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.Entities
{
    public class Car
    {
        [DisplayName("Car ID")]
        public int CarId { get; set; }
        [Required]
        [DisplayName("Car Type")]
        public string CarType { get; set; }

    }
}
