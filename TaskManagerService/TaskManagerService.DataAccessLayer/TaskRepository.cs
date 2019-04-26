using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerService.Entities;

namespace TaskManagerService.DataAccessLayer
{
    public class TaskRepository : IRepository<UserTask>, IDisposable
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

        public List<UserTask> SelectAll()
        {
            throw new NotImplementedException();
        }

        public UserTask SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserTask entity)
        {
            throw new NotImplementedException();
        }
    }
}
