using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerService.Entities;

namespace TaskManagerService.DataAccessLayer
{
    public class UserRepository
    {
        TaskDataContext context;
        public UserRepository()
        {
            context = new TaskDataContext();
        }
        public List<UsersModel> GetUserDetails()
        {
            try
            {
                List<UsersModel> usrModel = new List<UsersModel>();
                var usersList=context.Users.ToList();
                foreach (var item in usersList)
                {
                    UsersModel user = new UsersModel();
                    user.FirstName = item.FirstName;
                    user.LastName = item.LastName;
                    user.Employee_Id = item.Employee_Id;
                    user.User_Id = item.User_Id;
                    usrModel.Add(user);
                }
                return usrModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Insert(UsersModel record)
        {
            try
            {
                Users user = new Users();
                user.FirstName = record.FirstName;
                user.LastName = record.LastName;
                user.Employee_Id = record.Employee_Id;                
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
