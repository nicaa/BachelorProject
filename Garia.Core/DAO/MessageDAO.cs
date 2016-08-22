using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLToolkit.DataAccess;
using Garia.Core.Entities;

namespace Garia.Core.DAO
{
    public abstract class MessageDAO : DataAccessor
    {
        [SprocName("tblMessage_GetUserMessages")]
        public abstract List<Message> GetUserMessages(int RecieverId);

        [SprocName("tblMessage_GetUserSentMessages")]
        public abstract List<Message> GetUserSentMessages(int SenderId);


        [SprocName("tblMessage_MessageRead")]
        public abstract int MessageRead(int MessageId);

        [SprocName("tblMessage_GetunreadById")]
        public abstract int GetunreadById(int RecieverId);

        [SprocName("tblMessage_DeleteMessage")]
        public abstract int DeleteMessage(int MessageId);

        [SprocName("tblMessage_CreateMessage")]
        public abstract int CreateMessage(string Title, string MessageText, int SenderId, int RecieverId);

        [SprocName("tblMessage_getMessageById")]
        public abstract Message getMessageById(int MessageId);


    }
}
