using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garia.Core.Entities;
namespace Garia.Models
{
    public class CarModel
    {
        public Car car{ get; set; }
        public List<Car> CarList{ get; set; }
    }
}