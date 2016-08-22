using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garia.Core.Entities;

namespace Garia.Models
{
    public class CreateSaleModel
    {
        public Sale Sale { get; set; }

        public List<Car> car { get; set; }
        public List<Dealer> dealer { get; set; }
        public int employeeId{ get; set; }
        
    }
}