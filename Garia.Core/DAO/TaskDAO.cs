using BLToolkit.DataAccess;
using Garia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.DAO
{
    public abstract class TaskDAO : DataAccessor
    {
        [SprocName("tblTask_getTaskByRecieverId")]
        public abstract List<GariaTask> getTaskByRecieverId(int RecieverId);

        [SprocName("tblTask_getTaskBySenderId")]
        public abstract List<GariaTask> getTaskBySenderId(int SenderId);

        [SprocName("tblTask_getCompletedTaskByRecieverId")]
        public abstract List<GariaTask> getCompletedTaskByRecieverId(int RecieverId);

        [SprocName("tblTask_GetUnconfirmedTaskNumber")]
        public abstract int GetUnconfirmedTaskNumber(int RecieverId);

        [SprocName("tblTaskPriority_Getall")]
        public abstract List<TaskPriority> GetallPriorities();

        [SprocName("tblTask_ConfirmByTaskId")]
        public abstract int ConfirmByTaskId(int TaskId);

        [SprocName("tblTask_CompleteByTaskId")]
        public abstract int CompleteByTaskId(int TaskId, DateTime DateCompleted);

        [SprocName("tblTask_CreateTask")]
        public abstract int CreateTask(string Title, string Description, DateTime CompletionDate, int SenderId, int RecieverId, int PriorityId);

        [SprocName("tblTask_EditTaskById")]
        public abstract int EditTaskById(int TaskId, string Title, string Description,int RecieverId, DateTime CompletionDate, int PriorityId);

        [SprocName("tblTask_GetTaskById")]
        public abstract GariaTask GetTaskById(int TaskId);

    }
}
