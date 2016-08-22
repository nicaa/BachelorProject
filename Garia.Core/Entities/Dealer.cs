using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.Entities
{
    public class Dealer
    {
        public int DealerId { get; set; }
        [Required]
        public string DealerName { get; set; }
        public int RegionId { get; set; }

        [Required]
        public float Budget { get; set; }

    }
}
