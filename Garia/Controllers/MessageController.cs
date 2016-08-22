using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Garia.Core.Handlers;
using Garia.Models;
using Garia.Core.Entities;
using PagedList;

namespace Garia.Controllers
{
    public class MessageController : Controller
    {
        [Authorize]
        public ActionResult Messages(int page = 1, int pagesize = 5)
        {

            MessageModel model = new MessageModel();
            model.MessageList = new PagedList<Message>(MessageHandler.GetUserMessages(Convert.ToInt32(User.Identity.Name)), page, pagesize);
            return View(model);
        }

        [Authorize]
        public ActionResult SentMessages(int page = 1, int pagesize = 5)
        {
            MessageModel model = new MessageModel();
            model.MessageListSent = new PagedList<Message>(MessageHandler.GetUserSentMessages(Convert.ToInt32(User.Identity.Name)), page, pagesize);

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            CreateMessage model = new CreateMessage();
            model.employees = EmployeeHandler.GetAllEmployees();

            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(CreateMessage model, int RecieverId)
        {

            MessageHandler.CreateMessage(model.Message.Title,model.Message.MessageText,Convert.ToInt32(User.Identity.Name), RecieverId);
            model.employees = EmployeeHandler.GetAllEmployees();
            return RedirectToAction("Messages");
        }
        [Authorize]
        [HttpPost]
        public ActionResult DeleteMessage(int messageId, int page = 1, int pagesize = 5)
        {
            MessageHandler.DeleteMessage(messageId);

            MessageModel model = new MessageModel();
            model.MessageList = new PagedList<Message>(MessageHandler.GetUserMessages(Convert.ToInt32(User.Identity.Name)), page, pagesize);
            return PartialView("_MessageList",model.MessageList);
        }
        [Authorize]
        [HttpGet]
        public ActionResult ViewMessage(int messageId)
        {
            Message model = MessageHandler.getMessageById(messageId);
            MessageHandler.MessageRead(messageId);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ViewMessageReply(Message model, string MessageText)
        {
            MessageHandler.CreateMessage(model.Title,MessageText,Convert.ToInt32(User.Identity.Name),model.SenderId);
            return RedirectToAction("Messages");
        }


	}
}