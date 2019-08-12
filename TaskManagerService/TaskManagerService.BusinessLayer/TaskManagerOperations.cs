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
        TaskDataContext _context;
        public TaskManagerOperations(TaskDataContext taskDataContext)
        {
            this._context = taskDataContext;
        }
        public List<UserTaskModel> GetTaskDetails()
        {
            try
            {
                List<UserTaskModel> taskdetails = null;
                var repository = new TaskRepository(_context);
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
                var repository = new TaskRepository(_context);
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
                var repository = new TaskRepository(_context);
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
            var repository = new TaskRepository(_context);
            opCompleted = repository.DeleteById(id);
            return opCompleted;
        }

        public object EndTask(int id)
        {
            bool opCompleted;
            var repository = new TaskRepository(_context);
            opCompleted = repository.EndTaskById(id);
            return opCompleted;
        }
    }
}
