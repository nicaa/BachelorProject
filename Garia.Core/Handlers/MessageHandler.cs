using BLToolkit.Reflection;
using Garia.Core.DAO;
using Garia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.Handlers
{
    public class MessageHandler
    {
        public static List<Message> GetUserMessages(int RecieverId)
        {
            MessageDAO message = TypeAccessor<MessageDAO>.CreateInstance();
            return message.GetUserMessages(RecieverId);
        }
        public static List<Message> GetUserSentMessages(int SenderId)
        {
            MessageDAO message = TypeAccessor<MessageDAO>.CreateInstance();
            return message.GetUserSentMessages(SenderId);
        }

        public static int MessageRead(int MessageId)
        {
            MessageDAO message = TypeAccessor<MessageDAO>.CreateInstance();
            return message.MessageRead(MessageId);
        }
        public static int GetunreadById(int RecieverId)
        {
            MessageDAO message = TypeAccessor<MessageDAO>.CreateInstance();
            return message.GetunreadById(RecieverId);
        }

        public static int DeleteMessage(int MessageId)
        {
            MessageDAO message = TypeAccessor<MessageDAO>.CreateInstance();
            return message.DeleteMessage(MessageId);
        }
        public static int CreateMessage(string Title, string MessageText, int SenderId, int RecieverId)
        {
            MessageDAO message = TypeAccessor<MessageDAO>.CreateInstance();
            return message.CreateMessage(Title, MessageText, SenderId,RecieverId);
        }

        public static Message getMessageById(int MessageId)
        {
            MessageDAO message = TypeAccessor<MessageDAO>.CreateInstance();
            return message.getMessageById(MessageId);
        }

    }
}
