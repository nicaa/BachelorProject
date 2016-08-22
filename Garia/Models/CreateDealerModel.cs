using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garia.Core.Entities;
namespace Garia.Models
{
    public class CreateDealerModel
    {

        public Dealer Dealer { get; set; }
        public List<Region> Regions{ get; set; }
    }
}