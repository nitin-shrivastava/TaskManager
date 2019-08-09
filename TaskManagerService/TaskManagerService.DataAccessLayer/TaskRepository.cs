using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerService.Entities;

namespace TaskManagerService.DataAccessLayer
{
    public class TaskRepository : IDisposable
    {
        TaskDataContext context;
        public TaskRepository()
        {
            context = new TaskDataContext();
        }
        public bool DeleteById(int id)
        {
            try
            {
               var element= context.UserTasks.Single(x=>x.Task_ID == id);
                context.UserTasks.Remove(element);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Insert(UserTaskModel entity)
        {
            try
            {
                UserTask userTask = new UserTask();
                userTask.ParentTask_ID = entity.ParentTask_ID;
                userTask.Priority = entity.Priority;
                userTask.Status = entity.Status??"Open";
                userTask.Project_ID = entity.Project_ID;
                userTask.TaskDetail = entity.TaskDetail;
                userTask.StartDate = entity.StartDate;
                userTask.EndDate = entity.EndDate;
                context.UserTasks.Add(userTask);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        public List<UserTaskModel> GetTaskDetails()
        {
            try
            {
                List<UserTaskModel> taskModelList = new List<UserTaskModel>();
                var taskList = context.UserTasks.ToList();
                foreach (var taskItem in taskList)
                {
                    var UTM = new UserTaskModel()
                    {
                        Task_ID=taskItem.Task_ID,
                        ParentTask_ID = taskItem.ParentTask_ID,
                        ParentTaskDetail=taskList.Where(x=>x.ParentTask_ID == taskItem.Task_ID).Select(x=>x.TaskDetail).FirstOrDefault()??"No parent task",
                        TaskDetail = taskItem.TaskDetail,
                        StartDate = taskItem.StartDate,
                        EndDate = taskItem.EndDate,
                        Priority = taskItem.Priority,
                        Status = taskItem.Status
                    };
                    taskModelList.Add(UTM);

                }
                return taskModelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserTaskModel GetTaskDetailsById(int id)
        {
            var taskModel = (from c in context.UserTasks
                             where c.Task_ID == id
                             select c).FirstOrDefault();

            var UTM = new UserTaskModel()
            {
                Task_ID = taskModel.Task_ID,
                ParentTask_ID = taskModel.ParentTask_ID,
                TaskDetail = taskModel.TaskDetail,
                StartDate = taskModel.StartDate,
                EndDate = taskModel.EndDate,
                Priority = taskModel.Priority,
                Status = taskModel.Status
            };
            return UTM;
        }


        public bool Update(UserTask entity)
        {
            throw new NotImplementedException();
        }
    }
}
