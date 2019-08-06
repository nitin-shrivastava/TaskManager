using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerService.Entities
{
    public class UsersModel
    {
        public int User_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Employee_Id { get; set; }
        public int Project_Id { get; set; }
        public int Task_Id { get; set; }
    }
}
