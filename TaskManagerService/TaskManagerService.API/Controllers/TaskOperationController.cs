using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagerService.BusinessLayer;
using TaskManagerService.Entities;

namespace TaskManagerService.API.Controllers
{
    public class TaskOperationController : ApiController, IDisposable
    {

        // GET api/values
        public List<UserTask> GetTaskDetails()
        {
            try
            {
                using (var task = new TaskManagerOperations())
                {
                    return task.GetTaskDetails();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/values/5
        //[Route("GetTaskDetailsById/{id}")]

        public UserTask GetTaskDetailsById(int id)
        {
            try
            {
                using (var task = new TaskManagerOperations())
                {
                    return task.GetTaskDetailsById(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/values
        public void Post([FromBody]UserTask record)
        {
            try
            {
                using (var task = new TaskManagerOperations())
                {
                    var entity = new UserTask();
                    entity.TaskDetail = record.TaskDetail;
                    entity.StartDate = record.StartDate;
                    entity.EndDate = record.EndDate;
                    entity.Priority = record.Priority;
                    entity.Status = record.Status;
                    entity.ParentTask_ID = record.ParentTask_ID;
                    var opSuccess = task.InsertTask(entity);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
