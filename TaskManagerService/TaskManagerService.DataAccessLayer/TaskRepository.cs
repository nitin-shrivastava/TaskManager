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
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Insert(UserTask entity)
        {
            try
            {
                context.UserTasks.Add(entity);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        public List<UserTask> GetTaskDetails()
        {
            try
            {
                List<UserTask> taskModelList = new List<UserTask>();
                var taskList = context.UserTasks.ToList();
                foreach (var taskItem in taskList)
                {
                    var UTM = new UserTask()
                    {
                        ParentTask_ID = taskItem.ParentTask_ID,
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

        public UserTask GetTaskDetailsById(int id)
        {
            var taskModel = (from c in context.UserTasks
                             where c.Task_ID == id
                             select c).FirstOrDefault();

            var UTM = new UserTask()
            {
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
