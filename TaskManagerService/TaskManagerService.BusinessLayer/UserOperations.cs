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

        public object InsertUserDetails(UsersModel record)
        {
            try
            {
                bool opCompleted;
                var repository = new UserRepository();
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
                var repository = new UserRepository();
                userdetails = repository.GetUserDetails();
                return userdetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
