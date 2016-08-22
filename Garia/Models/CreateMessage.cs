using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garia.Core.Entities;
namespace Garia.Models
{
    public class CreateMessage
    {
        public Message Message{ get; set; }
        public List<Employee> employees { get; set; }

    }
}