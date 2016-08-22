using Garia.Core.Entities;
using Garia.Core.Handlers;
using Garia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garia.Controllers
{
    public class TaskController : Controller
    {

        [Authorize]
        public ActionResult Index()
        {
            
            //List<GariaTask> list =TaskHandler.getTaskByRecieverId(5);
            //List<GariaTask> list1 = TaskHandler.getTaskBySenderId(4);
            //List<GariaTask> list2 = TaskHandler.getCompletedTaskByRecieverId(5);
            //List<TaskPriority> list3 = TaskHandler.GetallPriorities();

            //int count = TaskHandler.GetUnconfirmedTaskNumber(5);
            //TaskHandler.CreateTask("Title Controller", "Description Controller", DateTime.Now,4,5,2);
            //TaskHandler.EditTaskById(5,"edit controllerl","Edit controller Description",DateTime.Now.AddDays(4),1);
            //TaskHandler.CompleteByTaskId(5,DateTime.Now);
            //TaskHandler.ConfirmByTaskId(5);

            

            TaskModel model = new TaskModel();
            model.TaskList = TaskHandler.getTaskByRecieverId(Convert.ToInt32(User.Identity.Name));

            return View(model);
        }

        [Authorize]
        public ActionResult CreatedTask()
        {
            TaskModel model = new TaskModel();
            model.TaskList = TaskHandler.getTaskBySenderId(Convert.ToInt32(User.Identity.Name));
            return View(model);
        }

        [Authorize]
        public ActionResult CompletedTask()
        {
            TaskModel model = new TaskModel();
            model.TaskList = TaskHandler.getCompletedTaskByRecieverId(Convert.ToInt32(User.Identity.Name));
            return View(model);
        }
        [Authorize]
        [HttpGet]
        public ActionResult CreateTask()
        {
            TaskCreateEditModel model = new TaskCreateEditModel();
            model.EmployeeList = EmployeeHandler.GetAllEmployees();
            model.prioritiesList = TaskHandler.GetallPriorities();
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateTask(TaskCreateEditModel model, int EmployeeId, int PriorityId)
        {
            if(ModelState.IsValid){
                TaskHandler.CreateTask(model.Task.Title, model.Task.Description,model.Task.CompletionDate ,Convert.ToInt32(User.Identity.Name), EmployeeId,PriorityId);
                return RedirectToAction("CreatedTask");
            }
             
            model.EmployeeList = EmployeeHandler.GetAllEmployees();
            model.prioritiesList = TaskHandler.GetallPriorities();
            return View(model);
        }
        [Authorize]
        public ActionResult EditTask(int TaskId)
        {
            TaskCreateEditModel model = new TaskCreateEditModel();
            model.Task = TaskHandler.GetTaskById(TaskId);
            model.EmployeeList = EmployeeHandler.GetAllEmployees();
            model.prioritiesList = TaskHandler.GetallPriorities();
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public ActionResult EditTask1(TaskCreateEditModel model, int EmployeeId, int PriorityId)
        {
            if (ModelState.IsValid)
            {
                TaskHandler.EditTaskById(model.Task.TaskId, model.Task.Title, model.Task.Description, EmployeeId, model.Task.CompletionDate, PriorityId);
                return RedirectToAction("CreatedTask");
            }

            model.EmployeeList = EmployeeHandler.GetAllEmployees();
            model.prioritiesList = TaskHandler.GetallPriorities();
            return View(model);
        }

       
        [Authorize]
        [HttpPost]
        public ActionResult ConfirmTaskAjax(int TaskId, string Title, int SenderId )
        {
            TaskHandler.ConfirmByTaskId(TaskId);
            MessageHandler.CreateMessage("Task: " + Title, "Task: " + Title + " Has been confirmed", Convert.ToInt32(User.Identity.Name), SenderId);
            TaskModel model = new TaskModel();
            model.TaskList = TaskHandler.getTaskByRecieverId(Convert.ToInt32(User.Identity.Name));
            return PartialView("_TaskComponet", model.TaskList);
        }
        [Authorize]
        [HttpPost]
        public ActionResult CompleteTaskAjax(int TaskId, string Title, int SenderId)
        {
            TaskHandler.CompleteByTaskId(TaskId, DateTime.Now);
            MessageHandler.CreateMessage("Task: " + Title, "Task: " + Title + " Has been Completed", Convert.ToInt32(User.Identity.Name), SenderId);
            TaskModel model = new TaskModel();
            model.TaskList = TaskHandler.getTaskByRecieverId(Convert.ToInt32(User.Identity.Name));
            return PartialView("_TaskComponet", model.TaskList);
        }

	}
}