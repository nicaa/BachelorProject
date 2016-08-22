using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.Entities
{
    public class Social
    {
        public int SocialId { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
        public int EmployeeId { get; set; }
        public int Likes { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> LikeList { get; set; }



    }
}
