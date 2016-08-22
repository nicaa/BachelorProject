using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.Entities
{
    public class Message
    {
        public int MessageId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title must be less than 100 characters")]
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        public string MessageText { get; set; }
        public int MessageRead { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public string SenderFname { get; set; }
        public string SenderLname { get; set; }
        public string RecieverFname { get; set; }
        public string RecieverLname { get; set; }
    }
}
