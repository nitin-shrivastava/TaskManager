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
