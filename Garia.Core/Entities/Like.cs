using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.Entities
{
    public class Like
    {
        public int LikeId { get; set; }
        public int EmployeeId { get; set; }
        public int SocialId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
    }
}
