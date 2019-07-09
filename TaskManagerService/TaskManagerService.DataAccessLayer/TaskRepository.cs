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
               var element= context.UserTasks.Where(x=>x.Task_ID==id).FirstOrDefault();
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

        public UserTaskModel GetTaskDetailsById(int id)
        {
            var taskModel = (from c in context.UserTasks
                             where c.Task_ID == id
                             select c).FirstOrDefault();

            var UTM = new UserTaskModel()
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
