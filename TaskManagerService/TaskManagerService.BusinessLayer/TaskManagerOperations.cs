using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerService.DataAccessLayer;
using TaskManagerService.Entities;

namespace TaskManagerService.BusinessLayer
{
    public class TaskManagerOperations : IDisposable
    {
        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public List<UserTaskModel> GetTaskDetails()
        {
            try
            {
                List<UserTaskModel> taskdetails = null;
                var repository = new TaskRepository();
                taskdetails = repository.GetTaskDetails();
                return taskdetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserTaskModel GetTaskDetailsById(int id)
        {
            try
            {
                var repository = new TaskRepository();
                return repository.GetTaskDetailsById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertTask(UserTaskModel taskEntity)
        {
            try
            {
                bool opCompleted;
                var repository = new TaskRepository();
                opCompleted = repository.Insert(taskEntity);
                return opCompleted;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool DeleteTask(int id)
        {
            bool opCompleted;
            var repository = new TaskRepository();
            opCompleted = repository.DeleteById(id);
            return opCompleted;
        }

        public object EndTask(int id)
        {
            bool opCompleted;
            var repository = new TaskRepository();
            opCompleted = repository.EndTaskById(id);
            return opCompleted;
        }
    }
}
