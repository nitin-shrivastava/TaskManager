using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerService.DataAccessLayer;
using TaskManagerService.Entities;

namespace TaskManagerService.BusinessLayer
{
    public class UserOperations : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        TaskDataContext _context;
        public UserOperations(TaskDataContext taskDataContext)
        {
            this._context = taskDataContext;
        }
        public object InsertUserDetails(UsersModel record)
        {
            try
            {
                bool opCompleted;
                var repository = new UserRepository(_context);
                opCompleted = repository.Insert(record);
                return opCompleted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetUserDetails()
        {
            try
            {
                List<UsersModel> userdetails = null;
                var repository = new UserRepository(_context);
                userdetails = repository.GetUserDetails();
                return userdetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object DeleteUserDetails(int userID)
        {
            try
            {
                bool opCompleted;
                var repository = new UserRepository(_context);                
                opCompleted = repository.DeleteUserDetails(userID);
                return opCompleted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
