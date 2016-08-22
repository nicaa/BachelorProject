using Garia.Core.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garia.Models
{
    public class MessageModel
    {
        public PagedList<Message> MessageList { get; set; }
        public PagedList<Message> MessageListSent { get; set; }

    }
}