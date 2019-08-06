using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerService.Entities
{
   public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Employee_Id { get; set; }
        public int? Project_Id { get; set; }
        public int? Task_Id { get; set; }
        public virtual Projects Projects { get; set; }
        public virtual UserTask Task { get; set; }
    }
}
