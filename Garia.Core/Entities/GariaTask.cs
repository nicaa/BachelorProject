using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.Entities
{
    public class GariaTask
    {
        public int TaskId { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "Title must be less than 300 characters")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int Confirmed { get; set; }
        public int Completed { get; set; }
        public DateTime DateCreated { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CompletionDate { get; set; }
        public DateTime DateCompleted { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public int PriorityId { get; set; }
        public string Sendername { get; set; }
        public string CreatorName { get; set; }
        public string Color { get; set; }
        public string Level { get; set; }
        public int DaysLeft
        {
            //Get total days left of task
            get
            {
                DateTime d1 = DateTime.Now;

                int days = (CompletionDate.Date - d1.Date).Days;
                return days;
            }
        }

    }
}
