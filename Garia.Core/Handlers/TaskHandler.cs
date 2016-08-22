using Garia.Core.Entities;
using Garia.Core.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLToolkit.Reflection;

namespace Garia.Core.Handlers
{
    public class TaskHandler
    {
        public static List<GariaTask> getTaskByRecieverId(int RecieverId)
        {
            
            TaskDAO task = TypeAccessor<TaskDAO>.CreateInstance();
            return task.getTaskByRecieverId(RecieverId);
        }
        public static List<GariaTask> getTaskBySenderId(int SenderId)
        {
            TaskDAO task = TypeAccessor<TaskDAO>.CreateInstance();
            return task.getTaskBySenderId(SenderId);
        }
        public static List<GariaTask> getCompletedTaskByRecieverId(int RecieverId)
        {
            TaskDAO task = TypeAccessor<TaskDAO>.CreateInstance();
            return task.getCompletedTaskByRecieverId(RecieverId);
        }
        public static int GetUnconfirmedTaskNumber(int RecieverId)
        {
            TaskDAO task = TypeAccessor<TaskDAO>.CreateInstance();
            return task.GetUnconfirmedTaskNumber(RecieverId);
        }
        public static List<TaskPriority> GetallPriorities()
        {
            TaskDAO task = TypeAccessor<TaskDAO>.CreateInstance();
            return task.GetallPriorities();
        }
        public static int ConfirmByTaskId(int TaskId)
        {
            TaskDAO task = TypeAccessor<TaskDAO>.CreateInstance();
            return task.ConfirmByTaskId(TaskId);
        }
        public static int CompleteByTaskId(int TaskId, DateTime DateCompleted)
        {
            TaskDAO task = TypeAccessor<TaskDAO>.CreateInstance();
            return task.CompleteByTaskId(TaskId, DateCompleted);
        }

        public static int CreateTask(string Title, string Description, DateTime CompletionDate, int SenderId, int RecieverId, int PriorityId)
        {
            TaskDAO task = TypeAccessor<TaskDAO>.CreateInstance();
            return task.CreateTask(Title, Description,CompletionDate,SenderId,RecieverId,PriorityId);
        }
        public static int EditTaskById(int TaskId, string Title, string Description,int RecieverId, DateTime CompletionDate, int PriorityId)
        {
            TaskDAO task = TypeAccessor<TaskDAO>.CreateInstance();
            return task.EditTaskById(TaskId,Title, Description,RecieverId, CompletionDate, PriorityId);
        }
        public static GariaTask GetTaskById(int TaskId)
        {
            TaskDAO task = TypeAccessor<TaskDAO>.CreateInstance();
            return task.GetTaskById(TaskId);
        }


    }
}
