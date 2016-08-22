using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime Date { get; set; }
        public string EmployeeName { get; set; }
        public int SocialId { get; set; }

    }
}
