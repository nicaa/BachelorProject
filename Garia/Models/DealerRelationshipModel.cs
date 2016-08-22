using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garia.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Garia.Models
{
    public class DealerRelationshipModel
    {

        [Required]
        public List<Dealer> Dealers { get; set; }
        [Required]
        public List<Employee> Employees { get; set; }

    }
}