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
        public List<UserTask> GetTaskDetails()
        {
            try
            {
                using (var repository = new TaskRepository())
                {
                    var taskdetails = repository.GetTaskDetails();
                    return taskdetails;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserTask GetTaskDetailsById(int id)
        {
            try
            {
                using (var repository = new TaskRepository())
                {
                    return repository.GetTaskDetailsById(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertTask(UserTask taskEntity)
        {
            try
            {
                bool opCompleted;
                using (var repository = new TaskRepository())
                {
                    opCompleted = repository.Insert(taskEntity);
                }
                return opCompleted;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
